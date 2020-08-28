using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Storing.DTO;
using BugTracker.Storing.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Storing.Repositories
{
    public class UserRepo : AbstractRepo
    {
        public UserRepo(BugTrackerDbContext dbContext) : base(dbContext) { }

        public async Task<UserDTO> ReadUserAsync(int id)
        {
            var user = await _db.Users
                .Include(x => x.Role)
                .SingleOrDefaultAsync(x => x.UserId == id);

            return new UserDTO(user);
        }

        public async Task<UserDTO> ReadUserByEmailAsync(string email)
        {
            var user = await _db.Users
                .Include(x => x.Role)
                .SingleOrDefaultAsync(x => x.Email == email);

            return new UserDTO(user);
        }

        public async Task<List<UserDTO>> ReadAllUsersAsync()
        {
            var users = await _db.Users
                .Include(x => x.Role)
                .ToListAsync();

            var userDTOList = new List<UserDTO>();

            foreach (var user in users)
            {
                userDTOList.Add(new UserDTO(user));
            }

            return userDTOList;
        }

        public async Task<List<UserDTO>> ReadUsersByRoleAsync(string role)
        {
            var users = await _db.Users
                .Where(x => x.Role.Name == role)
                .Include(x => x.Role)
                .ToListAsync();

            var userDTOList = new List<UserDTO>();

            foreach (var user in users)
            {
                userDTOList.Add(new UserDTO(user));
            }

            return userDTOList;
        }

        public async Task<List<string>> ReadRoles()
        {
            return await _db.UserRole.Select(x => x.Name).ToListAsync();
        }

        public async Task<int> CreateUserAsync(UserDTO userDTO)
        {
            var user = new Users()
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                Role = await _db.UserRole.SingleAsync(x => x.Name == userDTO.Role)
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return user.UserId;
        }

        public async Task UpdateUserAsync(UserDTO userDTO)
        {
            var user = await _db.Users.SingleAsync(x => x.UserId == userDTO.UserId);

            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;
            user.Email = userDTO.Email;
            user.Role = await _db.UserRole.SingleAsync(x => x.Name == userDTO.Role);

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