using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.Storing.DTO;
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

        [HttpGet("{ticketId}")]
        [ActionName("GetAsync")]
        public async Task<ActionResult<TicketDTO>> GetAsync(int ticketId)
        {
            if (await _repo.TicketExistsAsync(ticketId))
            {
                return Ok(await _repo.ReadTicketAsync(ticketId));
            }
            return NotFound("Ticket not found");
        }

        [HttpGet("history/{ticketId}")]
        public async Task<ActionResult<IEnumerable<TicketDTO>>> GetHistoryAsync(int ticketId)
        {
            if (await _repo.TicketExistsAsync(ticketId))
            {
                return Ok(await _repo.ReadTicketHistoryAsync(ticketId));
            }
            return NotFound("Ticket not found");
        }

        [HttpGet("priorities")]
        public async Task<ActionResult<IEnumerable<string>>> GetPriorities()
        {
            return Ok(await _repo.ReadPrioritiesAsync());
        }

        [HttpGet("statuses")]
        public async Task<ActionResult<IEnumerable<string>>> GetStatuses()
        {
            return Ok(await _repo.ReadStatusesAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<string>>> GetTypes()
        {
            return Ok(await _repo.ReadTypesAsync());
        }

        [HttpPost("{projectId}")]
        public async Task<ActionResult<TicketDTO>> PostAsync(int projectId, TicketDTO ticket)
        {
            if (ticket is null)
            {
                return BadRequest();
            }
            if (!await _repo.ProjectExistsAsync(projectId))
            {
                return NotFound("Project not found");
            }
            if (ticket.Submitter is null || !await _repo.UserExistsAsync(ticket.Submitter.UserId))
            {
                return NotFound("Submitter not found");
            }
            if (ticket.Dev != null && ticket.Dev.UserId != 0 && !await _repo.UserExistsAsync(ticket.Dev.UserId))
            {
                return NotFound("Dev not found");
            }
            if (ticket.Priority is null || !await _repo.PriorityExistsAsync(ticket.Priority))
            {
                return NotFound("Priority not found");
            }
            if (ticket.Status is null || !await _repo.StatusExistsAsync(ticket.Status))
            {
                return NotFound("Status not found");
            }
            if (ticket.Type is null || !await _repo.TypeExistsAsync(ticket.Type))
            {
                return NotFound("Type not found");
            }

            var newId = await _repo.CreateTicketAsync(projectId, ticket);

            return CreatedAtAction(
                nameof(GetAsync),
                new { ticketId = newId },
                await _repo.ReadTicketAsync(newId)
            );
        }

        [HttpPost("comment/{ticketId}")]
        public async Task<ActionResult<TicketDTO>> PostCommentAsync(int ticketId, CommentDTO comment)
        {
            if (!await _repo.UserExistsAsync(comment.Commenter.UserId))
            {
                return NotFound("Commenter not found");
            }

            await _repo.AddCommentAsync(ticketId, comment);

            return CreatedAtAction(
                nameof(GetAsync),
                new { ticketId = ticketId },
                await _repo.ReadTicketAsync(ticketId)
            );
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(TicketDTO ticket)
        {
            if (ticket is null)
            {
                return BadRequest("Ticket is null");
            }
            if (!await _repo.TicketExistsAsync(ticket.TicketId))
            {
                return NotFound("Ticket not found");
            }
            if (ticket.Submitter is null || !await _repo.UserExistsAsync(ticket.Submitter.UserId))
            {
                return NotFound("Submitter not found");
            }
            if (ticket.Dev != null && ticket.Dev.UserId != 0 && !await _repo.UserExistsAsync(ticket.Dev.UserId))
            {
                return NotFound("Dev not found");
            }
            if (ticket.Updater is null || !await _repo.UserExistsAsync(ticket.Updater.UserId))
            {
                return NotFound("Submitter not found");
            }
            if (ticket.Priority is null || !await _repo.PriorityExistsAsync(ticket.Priority))
            {
                return NotFound("Priority not found");
            }
            if (ticket.Status is null || !await _repo.StatusExistsAsync(ticket.Status))
            {
                return NotFound("Status not found");
            }
            if (ticket.Type is null || !await _repo.TypeExistsAsync(ticket.Type))
            {
                return NotFound("Type not found");
            }

            await _repo.UpdateTicketAsync(ticket);
            return NoContent();
        }

        [HttpDelete("{ticketId}")]
        public async Task<IActionResult> DeleteAsync(int ticketId)
        {
            if (await _repo.TicketExistsAsync(ticketId))
            {
                await _repo.DeleteTicketAsync(ticketId);
                return NoContent();
            }
            return NotFound("Ticket not found");
        }
    }
}