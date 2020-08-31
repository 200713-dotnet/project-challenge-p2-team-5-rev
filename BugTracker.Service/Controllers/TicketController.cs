using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.Service.HttpHandler;
using BugTracker.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Service.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TicketController : ControllerBase
  {
    private readonly TicketHttpHandler httpHandler = new TicketHttpHandler();

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ticket>>> Get()
    {
      var tickets = await httpHandler.GetTicketsAsync();
      if(tickets.Count == 0)
      {
        return NoContent();
      }
      return Ok(tickets);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      var ticket = httpHandler.GetTicketsByIdAsync(id);
      if(ticket!=null)
      {
        return Ok(ticket);
      }
      return NoContent();
    }

    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<ActionResult<IEnumerable<Ticket>>> GetTicketsByProjectId(int id)
    {
      var tickets = await httpHandler.GetTicketsByProjectId(id);
      if(tickets.Count == 0)
      {
        return NoContent();
      }
      return Ok(tickets);
    }

    [HttpPost]
    public IActionResult PostAsync(Ticket ticket)
    {
      if(ticket is null)
      {
        return BadRequest();
      }
      var newId = httpHandler.PostTicketAsync(ticket);
      if (newId.Result > 0)
      {
        ticket.TicketId = newId.Result;
        System.Console.WriteLine("Is Succesful - API");
        return CreatedAtAction(nameof(GetById), new { id = newId.Result }, ticket);
      }
      else
      {
        System.Console.WriteLine("Is Not Succesful - API");
        return NotFound();
      }
    }

    [HttpPut]
    public IActionResult PutTicket(int id, Ticket ticket)
    {
      if (id != ticket.TicketId)
      {
        return BadRequest();
      }
      var success = httpHandler.PutTicketAsync(id, ticket);
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

    // DELETE: api/Ticket/5
    [HttpDelete("{id}")]
    public ActionResult<Ticket> DeleteTicket(int id)
    {
      var success = httpHandler.DeleteTicketAsync(id);
      if (success.Result)
      {
        System.Console.WriteLine("Delete Succesful - API");
        return NoContent();
      }
      else
      {
        System.Console.WriteLine("Delete not succesful - API");
        return NotFound("Ticket not found");
      }
    }
  }
}