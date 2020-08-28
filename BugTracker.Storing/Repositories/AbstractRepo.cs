using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Storing.Repositories
{
    public abstract class AbstractRepo
    {
        protected readonly BugTrackerDbContext _db;

        protected AbstractRepo(BugTrackerDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<bool> ProjectExistsAsync(int projectId)
        {
            var result = await _db.Project.SingleOrDefaultAsync(x => x.ProjectId == projectId);

            if (result is null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> TicketExistsAsync(int ticketId)
        {
            var result = await _db.Ticket.SingleOrDefaultAsync(x => x.TicketId == ticketId);

            if (result is null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> UserExistsAsync(int userId)
        {
            var result = await _db.Users.SingleOrDefaultAsync(x => x.UserId == userId);

            if (result is null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> UserExistsAsync(string email)
        {
            var result = await _db.Users.SingleOrDefaultAsync(x => x.Email == email);

            if (result is null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> PriorityExistsAsync(string priority)
        {
            var result = await _db.TicketPriority.SingleOrDefaultAsync(x => x.Name == priority);

            if (result is null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> StatusExistsAsync(string status)
        {
            var result = await _db.TicketStatus.SingleOrDefaultAsync(x => x.Name == status);

            if (result is null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> TypeExistsAsync(string type)
        {
            var result = await _db.TicketType.SingleOrDefaultAsync(x => x.Name == type);

            if (result is null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> RoleExistsAsync(string role)
        {
            var result = await _db.UserRole.SingleOrDefaultAsync(x => x.Name == role);

            if (result is null)
            {
                return false;
            }
            return true;
        }
    }
}