using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<Ticket> ReadTicketAsync(int id)
        {
            return await _db.Ticket
                .Include(x => x.Comments)
                    .ThenInclude(x => x.Commenter)
                .Include(x => x.Dev)
                .Include(x => x.Priority)
                .Include(x => x.Project)
                .Include(x => x.Status)
                .Include(x => x.Submitter)
                .Include(x => x.Type)
                .SingleOrDefaultAsync(x => x.TicketId == id);
        }

        public async Task<List<Ticket>> ReadTicketHistoryAsync(int id)
        {
            return await _db.Ticket
                .FromSqlInterpolated($"SELECT * FROM Tickets.fn_getTicketHistory({id})")
                .AsNoTracking()
                .OrderBy(x => x.ValidFrom)
                // .Include(x => x.Comments)
                //     .ThenInclude(x => x.Commenter)
                .Include(x => x.Dev)
                .Include(x => x.Priority)
                .Include(x => x.Project)
                .Include(x => x.Status)
                .Include(x => x.Submitter)
                .Include(x => x.Type)
                .Include(x => x.Updater)
                .ToListAsync();
        }

        public async Task<List<TicketPriority>> ReadPrioritiesAsync()
        {
            return await _db.TicketPriority.ToListAsync();
        }

        public async Task<List<TicketStatus>> ReadStatusesAsync()
        {
            return await _db.TicketStatus.ToListAsync();
        }

        public async Task<List<TicketType>> ReadTypesAsync()
        {
            return await _db.TicketType.ToListAsync();
        }

        public async Task<int> CreateTicketAsync(int projectId, Ticket ticket)
        {
            ticket.Project = await _db.Project.SingleAsync(x => x.ProjectId == projectId);

            _db.Ticket.Add(ticket);
            await _db.SaveChangesAsync();

            return ticket.TicketId;
        }

        public async Task AddCommentAsync(int ticketId, Comment comment)
        {
            comment.Ticket = await _db.Ticket.SingleAsync(x => x.TicketId == ticketId);

            _db.Comment.Add(comment);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateTicketAsync(Ticket ticket)
        {
            _db.Ticket.Update(ticket);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteTicketAsync(int id)
        {
            _db.Ticket.Remove(
                await _db.Ticket.SingleOrDefaultAsync(x => x.TicketId == id)
            );
            await _db.SaveChangesAsync();
        }
    }
}