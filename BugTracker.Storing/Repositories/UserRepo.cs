using System.Collections.Generic;
using System.Linq;
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

        public Users ReadUser(int id)
        {
            return _db.Users
                .Include(x => x.AssignedTickets)
                .Include(x => x.ManagedProjects)
                .Include(x => x.Role)
                .Include(x => x.SubmittedTickets)
                .Include(x => x.UserProjects)
                    .ThenInclude(x => x.Project)
                .SingleOrDefault(x => x.UserId == id);
        }

        public List<Users> ReadAllUsers()
        {
            return _db.Users
                .Include(x => x.Role)
                .ToList();
        }

        public List<Users> ReadUsersByRole(int roleId)
        {
            return _db.Users
                .Where(x => x.RoleId == roleId)
                .Include(x => x.Role)
                .ToList();
        }

        public void CreateUser(string firstName, string lastName, string email, int roleId)
        {
            var user = new Users();

            user.FirstName = firstName;
            user.LastName = lastName;
            user.Email = email;
            user.Role = _db.UserRole.Single(x => x.RoleId == roleId);

            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public void UpdateUser(Users user)
        {
            _db.Users.Update(user);
            _db.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            _db.Users.Remove(
                _db.Users.SingleOrDefault(x => x.UserId == id)
            );
            _db.SaveChanges();
        }
    }
}