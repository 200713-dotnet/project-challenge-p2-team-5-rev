using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.Storing.DTO;
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
        public async Task<ActionResult<UserDTO>> LoginAsync(string email)
        {
            if (await _repo.UserExistsAsync(email))
            {
                return Ok(await _repo.ReadUserByEmailAsync(email));
            }
            return NotFound();
        }

        [HttpGet("{userId}")]
        [ActionName("GetAsync")]
        public async Task<ActionResult<UserDTO>> GetAsync(int userId)
        {
            if (await _repo.UserExistsAsync(userId))
            {
                return Ok(await _repo.ReadUserAsync(userId));
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllAsync()
        {
            var users = await _repo.ReadAllUsersAsync();

            if (users.Count == 0)
            {
                return NoContent();
            }
            return Ok(users);
        }

        [HttpGet("byrole/{role}")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetByRoleAsync(string role)
        {
            if (await _repo.RoleExistsAsync(role))
            {
                var users = await _repo.ReadUsersByRoleAsync(role);

                if (users.Count == 0)
                {
                    return NoContent();
                }
                return Ok(users);
            }
            return NotFound();
        }

        [HttpGet("roles")]
        public async Task<ActionResult<IEnumerable<string>>> GetRolesAsync()
        {
            return Ok(await _repo.ReadRoles());
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> PostAsync(UserDTO user)
        {
            if (!await _repo.RoleExistsAsync(user.Role))
            {
                return NotFound("Role not found");
            }

            var newId = await _repo.CreateUserAsync(user);

            return CreatedAtAction(
                nameof(GetAsync),
                new { userId = newId },
                await _repo.ReadUserAsync(newId)
            );
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(UserDTO user)
        {
            if (!await _repo.UserExistsAsync(user.UserId))
            {
                return NotFound("User not found");
            }
            if (!await _repo.RoleExistsAsync(user.Role))
            {
                return NotFound("Role not found");
            }

            await _repo.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteAsync(int userId)
        {
            if (await _repo.UserExistsAsync(userId))
            {
                await _repo.DeleteUserAsync(userId);
                return NoContent();
            }
            return NotFound();
        }
    }
}