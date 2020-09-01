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

        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetById(int id)
        {
            var ticket = await httpHandler.GetTicketsByIdAsync(id);
            if (ticket != null)
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
            if (tickets.Count == 0)
            {
                return NoContent();
            }
            return Ok(tickets);
        }

        [HttpPost("{projectId}")]
        public async Task<ActionResult<Ticket>> PostAsync(int projectId, Ticket ticket)
        {
            if (ticket is null)
            {
                return BadRequest();
            }
            var newTicket = await httpHandler.PostTicketAsync(projectId, ticket);
            if (newTicket is null)
            {
                return NotFound();
            }
            return CreatedAtAction
            (
                nameof(GetById),
                new { id = newTicket.TicketId },
                newTicket
            );
        }

        [HttpPut]
        public async Task<IActionResult> PutTicketAsync(Ticket ticket)
        {
            if (ticket is null)
            {
                return BadRequest();
            }
            var success = await httpHandler.PutTicketAsync(ticket);
            if (success)
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