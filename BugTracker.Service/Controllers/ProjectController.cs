using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BugTracker.Service.HttpHandler;
using BugTracker.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// dotnet add package Newtonsoft.Json --version 12.0.3

namespace BugTracker.Service.Controllers
{
  [Route("api/[controller]")]
  // [Route("api/[controller]/[action]")]
  [ApiController]
  public class ProjectController : ControllerBase
  {
    private readonly ProjectHttpHandler httpHandler = new ProjectHttpHandler();

    [HttpGet]
    [ActionName("GetProjects")] // when you specify the action in the routing
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
        project.ID = newId.Result;
        System.Console.WriteLine("Is Succesful - API");
        return CreatedAtAction(nameof(GetById), new { id = newId.Result }, project);
      }
      System.Console.WriteLine("Post Not succesful - API");
      return NotFound();
    }

    [HttpPut]
    public IActionResult PutProject(int id, Project project)
    {
      if (id != project.ID)
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
    [HttpDelete("{id}")]
    public ActionResult DeleteProject(int id)
    {
      var success = httpHandler.DeleteProjectAsync(id);
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