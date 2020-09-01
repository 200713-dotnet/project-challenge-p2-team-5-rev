using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.Service.HttpHandler;
using BugTracker.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Service.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProjectController : ControllerBase
  {
    private readonly ProjectHttpHandler httpHandler = new ProjectHttpHandler();

    [HttpGet]
    [ActionName("GetProjects")] 
    public async Task<ActionResult<IEnumerable<Project>>> Get()
    {
      var projects = await httpHandler.GetProjectsAsync();
      if(projects.Count == 0)
      {
        return NoContent();
      }
      return Ok(projects);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Project>> GetById(int id)
    {
      var project = await httpHandler.GetProjectByIdAsync(id);
      if(project!=null)
      {
        return Ok(project);
      }
      return NoContent();
    }

    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<ActionResult<IEnumerable<Project>>> GetProjectsByUserId(int id)
    {
      var projects = await httpHandler.GetProjectsByUserId(id);
      if(projects.Count == 0)
      {
        return NoContent();
      }
      return Ok(projects);
    }

    [HttpPost]
    public ActionResult<Project> PostAsync(Project project)
    {
      if(project == null)
      {
        return BadRequest();
      }
      var newId = httpHandler.PostProjectAsync(project);
      if (newId.Result > 0)
      {
        project.projectId = newId.Result;
        System.Console.WriteLine("Is Succesful - API");
        return CreatedAtAction(nameof(GetById), new { id = newId.Result }, project);
      }
      System.Console.WriteLine("Post Not succesful - API");
      return NotFound();
    }

    [HttpPut]
    public IActionResult PutProject(int id, Project project)
    {
      if (id != project.projectId)
      {
        return BadRequest();
      }
      var success = httpHandler.PutProjectAsync(id, project);
      if (success.Result)
      {
        System.Console.WriteLine("Is Succesful - API");
        return NoContent();
      }
      else
      {
        System.Console.WriteLine("is not succesful - API");
        return NotFound();
      }
    }

    // DELETE: api/Project/5
    [HttpDelete("{projectId}")]
    public ActionResult DeleteProject(int projectId)
    {
      var success = httpHandler.DeleteProjectAsync(projectId);
      if (success.Result)
      {
        System.Console.WriteLine("Delete Succesful - API");
        return NoContent();
      }
      else
      {
        System.Console.WriteLine("Delete not succesful - API");
        return NotFound("Project not found");
      }
    }
  }
}