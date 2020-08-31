using System;
using System.Collections.Generic;
using BugTracker.Storing.Models;

namespace BugTracker.Storing.DTO
{
    public class TicketDTO
    {
        public int TicketId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public UserDTO Dev { get; set; }
        public UserDTO Submitter { get; set; }
        public UserDTO Updater { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public DateTime DateCreated { get; set; }
        public List<CommentDTO> Comments { get; set; }

        public TicketDTO() { }

        public TicketDTO(Ticket ticket)
        {
            TicketId = ticket.TicketId;
            Title = ticket.Title;
            Description = ticket.Description;
            Submitter = new UserDTO(ticket.Submitter);
            Priority = ticket.Priority.Name;
            Status = ticket.Status.Name;
            Type = ticket.Type.Name;
            DateCreated = ticket.DateCreated;

            if (ticket.Updater != null)
            {
                Updater = new UserDTO(ticket.Updater);
            }

            if (ticket.Dev != null)
            {
                Dev = new UserDTO(ticket.Dev);
            }

            Comments = new List<CommentDTO>();
            foreach (var comment in ticket.Comments)
            {
                Comments.Add(new CommentDTO(comment));
            }
        }
    }
}