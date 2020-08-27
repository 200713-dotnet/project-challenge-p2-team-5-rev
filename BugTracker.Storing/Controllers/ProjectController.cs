using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.Storing.Models;
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

        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<Project>>> GetAllAsync(int userId)
        {
            var projects = await _repo.ReadProjectsByUserAsync(userId);

            if (projects == null)
            {
                return NotFound();
            }
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetAsync(int projectId)
        {
            var project = await _repo.ReadProjectAsync(projectId);

            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<Project>> PostAsync(Project project)
        {
            var newId = await _repo.CreateProjectAsync(project);

            return CreatedAtAction(
                nameof(GetAsync),
                new { id = newId },
                project
            );
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Project project)
        {
            if (await _repo.ReadProjectAsync(project.ProjectId) == null)
            {
                return NotFound();
            }

            await _repo.UpdateProjectAsync(project);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (await _repo.ReadProjectAsync(id) == null)
            {
                return NotFound();
            }

            await _repo.DeleteProjectAsync(id);
            return NoContent();
        }
    }
}