using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.Storing.DTO;
using BugTracker.Storing.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Storing.Controllers
{
    [Route("storing/[controller]")]
    public class ProjectController : ControllerBase
    {
        private ProjectRepo _repo;

        public ProjectController(BugTrackerDbContext dbContext)
        {
            _repo = new ProjectRepo(dbContext);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetByUserAsync(int userId)
        {
            if (await _repo.UserExistsAsync(userId))
            {
                var projects = await _repo.ReadProjectsByUserAsync(userId);

                if (projects.Count == 0)
                {
                    return NoContent();
                }
                return Ok(projects);
            }
            return NotFound("User not found");
        }

        [HttpGet("{projectId}")]
        [ActionName("GetAsync")]
        public async Task<ActionResult<ProjectDTO>> GetAsync(int projectId)
        {
            if (await _repo.ProjectExistsAsync(projectId))
            {
                return Ok(await _repo.ReadProjectAsync(projectId));
            }
            return NotFound("Project not found");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetAllAsync()
        {
            var projects = await _repo.ReadAllProjectsAsync();

            if (projects.Count == 0)
            {
                return NoContent();
            }
            return Ok(projects);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDTO>> PostAsync(ProjectDTO project)
        {
            if (project is null)
            {
                return BadRequest("Project is null");
            }
            if (project.Manager is null || !await _repo.UserExistsAsync(project.Manager.UserId))
            {
                return NotFound("Manager not found");
            }

            var newId = await _repo.CreateProjectAsync(project);

            return CreatedAtAction(
                nameof(GetAsync),
                new { projectId = newId },
                await _repo.ReadProjectAsync(newId)
            );
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(ProjectDTO project)
        {
            if (project is null)
            {
                return BadRequest("Project is null");
            }
            if (!await _repo.ProjectExistsAsync(project.ProjectId))
            {
                return NotFound("Project not found");
            }
            if (project.Manager is null || !await _repo.UserExistsAsync(project.Manager.UserId))
            {
                return NotFound("Manager not found");
            }

            await _repo.UpdateProjectAsync(project);
            return NoContent();
        }

        [HttpDelete("{projectId}")]
        public async Task<IActionResult> DeleteAsync(int projectId)
        {
            if (await _repo.ProjectExistsAsync(projectId))
            {
                await _repo.DeleteProjectAsync(projectId);
                return NoContent();
            }
            return NotFound("Project not found");
        }
    }
}