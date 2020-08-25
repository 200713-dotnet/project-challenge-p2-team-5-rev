using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.Service.HttpHandler;
using BugTracker.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Service.Controllers
{
  [Route("api/[controller]")]
  // [Route("api/[controller]/[action]")]
  [ApiController]
  public class TicketController : ControllerBase
  {
    private readonly TicketHttpHandler httpHandler = new TicketHttpHandler();

    [HttpGet]
    // [ActionName("GetAll")] // when you specify the action in the routing
    public async Task<ActionResult<IEnumerable<Ticket>>> Get()
    {
      return await httpHandler.GetTicketsAsync();
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      return Ok();
    }
    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<ActionResult<IEnumerable<Ticket>>> GetByProjectId(int id)
    {
      System.Console.WriteLine("get by project Id");
      return Ok();
    }

    [HttpPost]
    public IActionResult Post(Ticket ticket)
    {
      var success = httpHandler.PostTicketAsync(ticket);
      if (success.Result)
      {
        System.Console.WriteLine("Is Succesful - API");
        return CreatedAtAction(nameof(GetById), new { id = ticket.ID }, ticket);
      }
      else
      {
        System.Console.WriteLine("Is Not Succesful - API");
        return NotFound(); // FIXME
      }
    }
    // DELETE: api/Ticket/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Ticket>> DeleteTicket(int id)
    {
      return Ok();
    }
  }
}