using System.Collections.Generic;
using System.Linq;
using BugTracker.Storing.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Storing.Repositories
{
    public class TicketRepo
    {
        private readonly BugTrackerDbContext _db;

        public TicketRepo(BugTrackerDbContext dbContext)
        {
            _db = dbContext;
        }

        public Ticket ReadTicket(int id)
        {
            return _db.Ticket
                .Include(x => x.Comments)
                .Include(x => x.Dev)
                .Include(x => x.Priority)
                .Include(x => x.Project)
                .Include(x => x.Status)
                .Include(x => x.Submitter)
                .Include(x => x.Type)
                .SingleOrDefault(x => x.TicketId == id);
        }

        public List<Ticket> ReadTicketHistory(int id)
        {
            return _db.Ticket
                .FromSqlInterpolated($"SELECT * FROM Tickets.fn_getTicketHistory({id})")
                .AsNoTracking()
                .OrderBy(x => x.ValidFrom)
                // .Include(x => x.Comments)
                .Include(x => x.Dev)
                .Include(x => x.Priority)
                .Include(x => x.Project)
                .Include(x => x.Status)
                .Include(x => x.Submitter)
                .Include(x => x.Type)
                .Include(x => x.Updater)
                .ToList();
        }

        public void CreateTicket(string title, string description, int submitterId, int projectId, int priorityId, int statusId, int typeId)
        {
            var ticket = new Ticket();

            ticket.Title = title;
            ticket.Description = description;
            ticket.Submitter = _db.Users.Single(x => x.UserId == submitterId);
            ticket.Project = _db.Project.Single(x => x.ProjectId == projectId);
            ticket.Priority = _db.TicketPriority.Single(x => x.PriorityId == priorityId);
            ticket.Status = _db.TicketStatus.Single(x => x.StatusId == statusId);
            ticket.Type = _db.TicketType.Single(x => x.TypeId == typeId);

            _db.Ticket.Add(ticket);
            _db.SaveChanges();
        }

        public void AddComment(int ticketId, int commenterId, string text)
        {
            var comment = new Comment();

            comment.Ticket = _db.Ticket.Single(x => x.TicketId == ticketId);
            comment.Commenter = _db.Users.Single(x => x.UserId == commenterId);
            comment.Text = text;

            _db.Comment.Add(comment);
            _db.SaveChanges();
        }

        public void UpdateTicket(Ticket ticket)
        {
            _db.Ticket.Update(ticket);
            _db.SaveChanges();
        }

        // public void UpdateTitle(int id, string title, int updaterId)
        // {
        //     var ticket = _db.Ticket.SingleOrDefault(x => x.TicketId == id);

        //     ticket.Title = title;
        //     ticket.Updater = _db.Users.Single(x => x.UserId == updaterId);

        //     _db.Ticket.Update(ticket);
        //     _db.SaveChanges();
        // }

        // public void UpdateDescription(int id, string description, int updaterId)
        // {
        //     var ticket = _db.Ticket.SingleOrDefault(x => x.TicketId == id);

        //     ticket.Description = description;
        //     ticket.Updater = _db.Users.Single(x => x.UserId == updaterId);

        //     _db.Ticket.Update(ticket);
        //     _db.SaveChanges();
        // }

        // public void UpdateDeveloper(int id, int devId, int updaterId)
        // {
        //     var ticket = _db.Ticket.SingleOrDefault(x => x.TicketId == id);

        //     ticket.Dev = _db.Users.Single(x => x.UserId == devId);
        //     ticket.Updater = _db.Users.Single(x => x.UserId == updaterId);

        //     _db.Ticket.Update(ticket);
        //     _db.SaveChanges();
        // }

        // public void UpdatePriority(int id, int priorityId, int updaterId)
        // {
        //     var ticket = _db.Ticket.SingleOrDefault(x => x.TicketId == id);

        //     ticket.Priority = _db.TicketPriority.Single(x => x.PriorityId == priorityId);
        //     ticket.Updater = _db.Users.Single(x => x.UserId == updaterId);

        //     _db.Ticket.Update(ticket);
        //     _db.SaveChanges();
        // }

        // public void UpdateStatus(int id, int statusId, int updaterId)
        // {
        //     var ticket = _db.Ticket.SingleOrDefault(x => x.TicketId == id);

        //     ticket.Status = _db.TicketStatus.Single(x => x.StatusId == statusId);
        //     ticket.Updater = _db.Users.Single(x => x.UserId == updaterId);

        //     _db.Ticket.Update(ticket);
        //     _db.SaveChanges();
        // }

        // public void UpdateType(int id, int typeId, int updaterId)
        // {
        //     var ticket = _db.Ticket.SingleOrDefault(x => x.TicketId == id);

        //     ticket.Type = _db.TicketType.Single(x => x.TypeId == typeId);
        //     ticket.Updater = _db.Users.Single(x => x.UserId == updaterId);

        //     _db.Ticket.Update(ticket);
        //     _db.SaveChanges();
        // }

        public void DeleteTicket(int id)
        {
            _db.Ticket.Remove(
                _db.Ticket.SingleOrDefault(x => x.TicketId == id)
            );
            _db.SaveChanges();
        }
    }
}