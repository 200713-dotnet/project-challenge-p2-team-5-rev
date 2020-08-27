using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.Storing.Models;
using BugTracker.Storing.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Storing.Controllers
{
    [Route("storing/[controller]")]
    public class TicketController : ControllerBase
    {
        private TicketRepo _repo;

        public TicketController(BugTrackerDbContext dbContext)
        {
            _repo = new TicketRepo(dbContext);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetAsync(int id)
        {
            var ticket = await _repo.ReadTicketAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }

        [HttpGet("history/{id}")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetHistoryAsync(int id)
        {
            var tickets = await _repo.ReadTicketHistoryAsync(id);

            if (tickets == null)
            {
                return NotFound();
            }
            return Ok(tickets);
        }

        [HttpGet("priorities")]
        public async Task<ActionResult<IEnumerable<TicketPriority>>> GetPriorities()
        {
            return await _repo.ReadPrioritiesAsync();
        }

        [HttpGet("statuses")]
        public async Task<ActionResult<IEnumerable<TicketStatus>>> GetStatuses()
        {
            return await _repo.ReadStatusesAsync();
        }

        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<TicketType>>> GetTypes()
        {
            return await _repo.ReadTypesAsync();
        }

        [HttpPost("{projectId}")]
        public async Task<ActionResult<Ticket>> PostAsync(int projectId, Ticket ticket)
        {
            var ticketId = await _repo.CreateTicketAsync(projectId, ticket);

            return CreatedAtAction(
                nameof(GetAsync),
                new { id = ticketId },
                ticket
            );
        }

        [HttpPost("comment/{ticketId}")]
        public async Task<IActionResult> PostCommentAsync(int ticketId, Comment comment)
        {
            await _repo.AddCommentAsync(ticketId, comment);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Ticket ticket)
        {
            if (await _repo.ReadTicketAsync(ticket.ProjectId) == null)
            {
                return NotFound();
            }

            await _repo.UpdateTicketAsync(ticket);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (await _repo.ReadTicketAsync(id) == null)
            {
                return NotFound();
            }

            await _repo.DeleteTicketAsync(id);
            return NoContent();
        }
    }
}