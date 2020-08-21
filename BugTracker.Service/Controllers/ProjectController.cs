using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BugTracker.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BugTracker.Service.Controllers
{
  [Route("api/[controller]")]
  // [Route("api/[controller]/[action]")]
  [ApiController]
  public class ProjectController : ControllerBase
  {
    [HttpGet]
    // [ActionName("GetAll")] // when you specify the action in the routing
    public IActionResult Get()
    {
      return Ok();
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(Project project)
    {
      System.Console.WriteLine("API");
      var json = JsonConvert.SerializeObject(project);
      System.Console.WriteLine(json);
      var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
      var httpClient = new HttpClient();
      var response = await httpClient.PostAsync("http://localhost:5002/api/project", stringContent);

      if(response.IsSuccessStatusCode)
      {
        System.Console.WriteLine("Is Succesful");
        return StatusCode(201);
      }
      else{
        System.Console.WriteLine("is not succesful");
        return NotFound(); // FIXME
      }
    }
    // DELETE: api/Project/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Ticket>> DeleteProject(int id)
    {
      return Ok();
    }
  }
}