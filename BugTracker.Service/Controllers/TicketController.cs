using System.Threading.Tasks;
using BugTracker.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Service.Controllers
{
  [Route("api/[controller]")]
  // [Route("api/[controller]/[action]")]
  [ApiController]
  public class TicketController : ControllerBase
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
    public IActionResult Post(Ticket ticket)
    {
      return Ok();
    }
    // DELETE: api/Ticket/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Ticket>> DeleteTicket(int id)
    {
      return Ok();
    }
  }
}