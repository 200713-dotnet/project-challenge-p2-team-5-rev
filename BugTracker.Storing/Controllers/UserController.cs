using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.Storing.Models;
using BugTracker.Storing.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Storing.Controllers
{
    [Route("storing/[controller]")]
    public class UserController : ControllerBase
    {
        private UserRepo _repo;

        public UserController(BugTrackerDbContext dbContext)
        {
            _repo = new UserRepo(dbContext);
        }

        [HttpGet("login/{email}")]
        public async Task<ActionResult<Users>> LoginAsync(string email)
        {
            var user = await _repo.ReadUserByEmailAsync(email);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetAsync(int id)
        {
            var user = await _repo.ReadUserAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetAllAsync()
        {
            var users = await _repo.ReadAllUsersAsync();

            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpGet("byrole/{roleId}")]
        public async Task<ActionResult<IEnumerable<Users>>> GetByRole(int roleId)
        {
            var users = await _repo.ReadUsersByRoleAsync(roleId);

            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpGet("roles")]
        public async Task<ActionResult<IEnumerable<UserRole>>> GetRoles()
        {
            return await _repo.ReadRoles();
        }

        [HttpPost]
        public async Task<ActionResult<Users>> CreateUser(Users user)
        {
            var newId = await _repo.CreateUserAsync(user);

            return CreatedAtAction(
                nameof(GetAsync),
                new { id = newId },
                user
            );
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Users user)
        {
            if (await _repo.ReadUserAsync(user.UserId) == null)
            {
                return NotFound();
            }

            await _repo.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (await _repo.ReadUserAsync(id) == null)
            {
                return NotFound();
            }

            await _repo.DeleteUserAsync(id);
            return NoContent();
        }
    }
}