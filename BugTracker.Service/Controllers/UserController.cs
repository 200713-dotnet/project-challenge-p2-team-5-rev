// using System.Net.Http;
// using System.Text;
// using System.Threading.Tasks;
// using BugTracker.Service.Models;
// using Microsoft.AspNetCore.Mvc;
// using Newtonsoft.Json;

// // dotnet add package Newtonsoft.Json --version 12.0.3

// namespace BugTracker.Service.Controllers
// {
//   [Route("api/[controller]")]
//   // [Route("api/[controller]/[action]")]
//   [ApiController]
//   public class UserController : ControllerBase
//   {
//     [HttpGet]
//     // [ActionName("GetAll")] // when you specify the action in the routing
//     public IActionResult Get()
//     {
//       return Ok();
//     }
//     [HttpGet("{id}")]
//     public IActionResult GetById(int id)
//     {
//       return Ok();
//     }

//     [HttpPost]
//     public async Task<IActionResult> PostAsync(User user)
//     {
//       return Ok();
//     }
//     // DELETE: api/Project/5
//     [HttpDelete("{id}")]
//     public async Task<ActionResult<Ticket>> DeleteProject(int id)
//     {
//       return Ok();
//     }
//   }
// }