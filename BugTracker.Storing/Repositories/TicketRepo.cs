using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Storing.DTO;
using BugTracker.Storing.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Storing.Repositories
{
    public class TicketRepo : AbstractRepo
    {
        public TicketRepo(BugTrackerDbContext dbContext) : base(dbContext) { }

        public async Task<TicketDTO> ReadTicketAsync(int id)
        {
            var ticket = await _db.Ticket
                .Include(x => x.Comments)
                    .ThenInclude(x => x.Commenter)
                        .ThenInclude(x => x.Role)
                .Include(x => x.Dev)
                    .ThenInclude(x => x.Role)
                .Include(x => x.Priority)
                .Include(x => x.Status)
                .Include(x => x.Submitter)
                    .ThenInclude(x => x.Role)
                .Include(x => x.Type)
                .SingleOrDefaultAsync(x => x.TicketId == id);

            return new TicketDTO(ticket);
        }

        public async Task<List<TicketDTO>> ReadTicketHistoryAsync(int id)
        {
            var tickets = await _db.Ticket
                .FromSqlInterpolated($"SELECT * FROM Tickets.fn_getTicketHistory({id})")
                .AsNoTracking()
                .OrderBy(x => x.ValidFrom)
                .Include(x => x.Comments)
                    .ThenInclude(x => x.Commenter)
                        .ThenInclude(x => x.Role)
                .Include(x => x.Dev)
                    .ThenInclude(x => x.Role)
                .Include(x => x.Priority)
                .Include(x => x.Status)
                .Include(x => x.Submitter)
                    .ThenInclude(x => x.Role)
                .Include(x => x.Type)
                .Include(x => x.Updater)
                    .ThenInclude(x => x.Role)
                .ToListAsync();

            var ticketDTOList = new List<TicketDTO>();

            foreach (var ticket in tickets)
            {
                ticketDTOList.Add(new TicketDTO(ticket));
            }

            return ticketDTOList;
        }

        public async Task<List<string>> ReadPrioritiesAsync()
        {
            return await _db.TicketPriority.Select(x => x.Name).ToListAsync();
        }

        public async Task<List<string>> ReadStatusesAsync()
        {
            return await _db.TicketStatus.Select(x => x.Name).ToListAsync();
        }

        public async Task<List<string>> ReadTypesAsync()
        {
            return await _db.TicketType.Select(x => x.Name).ToListAsync();
        }

        public async Task<int> CreateTicketAsync(int projectId, TicketDTO ticketDTO)
        {
            var ticket = new Ticket()
            {
                Title = ticketDTO.Title,
                Description = ticketDTO.Description,
                Project = await _db.Project.SingleAsync(x => x.ProjectId == projectId),
                Submitter = await _db.Users.SingleAsync(x => x.UserId == ticketDTO.Submitter.UserId),
                Priority = await _db.TicketPriority.SingleAsync(x => x.Name == ticketDTO.Priority),
                Status = await _db.TicketStatus.SingleAsync(x => x.Name == ticketDTO.Status),
                Type = await _db.TicketType.SingleAsync(x => x.Name == ticketDTO.Type)
            };

            if (ticketDTO.Dev != null)
            {
                ticket.Dev = await _db.Users.SingleOrDefaultAsync(x => x.UserId == ticketDTO.Dev.UserId);
            }

            _db.Ticket.Add(ticket);
            await _db.SaveChangesAsync();

            return ticket.TicketId;
        }

        public async Task AddCommentAsync(int ticketId, CommentDTO commentDTO)
        {
            var comment = new Comment()
            {
                Ticket = await _db.Ticket.SingleAsync(x => x.TicketId == ticketId),
                Commenter = await _db.Users.SingleAsync(x => x.UserId == commentDTO.Commenter.UserId),
                Text = commentDTO.Text
            };

            _db.Comment.Add(comment);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateTicketAsync(TicketDTO ticketDTO)
        {
            var ticket = await _db.Ticket.SingleAsync(x => x.TicketId == ticketDTO.TicketId);

            ticket.Title = ticketDTO.Title;
            ticket.Description = ticketDTO.Description;
            ticket.Submitter = await _db.Users.SingleAsync(x => x.UserId == ticketDTO.Submitter.UserId);
            ticket.Updater = await _db.Users.SingleAsync(x => x.UserId == ticketDTO.Updater.UserId);
            ticket.Priority = await _db.TicketPriority.SingleAsync(x => x.Name == ticketDTO.Priority);
            ticket.Status = await _db.TicketStatus.SingleAsync(x => x.Name == ticketDTO.Status);
            ticket.Type = await _db.TicketType.SingleAsync(x => x.Name == ticketDTO.Type);

            if (ticketDTO.Dev != null)
            {
                ticket.Dev = await _db.Users.SingleOrDefaultAsync(x => x.UserId == ticketDTO.Dev.UserId);
            }

            await _db.SaveChangesAsync();
        }

        public async Task DeleteTicketAsync(int id)
        {
            var ticket = await _db.Ticket
                .Include(x => x.Comments)
                .SingleOrDefaultAsync(x => x.TicketId == id);

            foreach (var comment in ticket.Comments)
            {
                _db.Comment.Remove(comment);
            }

            _db.Ticket.Remove(ticket);
            await _db.SaveChangesAsync();
        }
    }
}