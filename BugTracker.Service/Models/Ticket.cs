using System;
using System.Collections.Generic;

namespace BugTracker.Service.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        public User Dev { get; set; }

        public User Submitter { get; set; }

        public User Updater { get; set; }

        public string Priority { get; set; }

        public string Status { get; set; }

        public string Type { get; set; }

        public List<Comment> Comments { get; set; }
    }
}