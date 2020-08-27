using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Storing.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Storing.Repositories
{
    public class UserRepo
    {
        private readonly BugTrackerDbContext _db;

        public UserRepo(BugTrackerDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<Users> ReadUserAsync(int id)
        {
            return await _db.Users
                .Include(x => x.Role)
                .SingleOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<Users> ReadUserByEmailAsync(string email)
        {
            return await _db.Users
                .Include(x => x.AssignedTickets)
                .Include(x => x.ManagedProjects)
                .Include(x => x.Role)
                .Include(x => x.SubmittedTickets)
                .Include(x => x.UserProjects)
                    .ThenInclude(x => x.Project)
                .SingleOrDefaultAsync(x => x.Email == email);
        }

        public async Task<List<Users>> ReadAllUsersAsync()
        {
            return await _db.Users
                .Include(x => x.Role)
                .ToListAsync();
        }

        public async Task<List<Users>> ReadUsersByRoleAsync(int roleId)
        {
            return await _db.Users
                .Where(x => x.RoleId == roleId)
                .Include(x => x.Role)
                .ToListAsync();
        }

        public async Task<List<UserRole>> ReadRoles()
        {
            return await _db.UserRole.ToListAsync();
        }

        public async Task<int> CreateUserAsync(Users user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return user.UserId;
        }

        public async Task UpdateUserAsync(Users user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            _db.Users.Remove(
                await _db.Users.SingleOrDefaultAsync(x => x.UserId == id)
            );
            await _db.SaveChangesAsync();
        }
    }
}