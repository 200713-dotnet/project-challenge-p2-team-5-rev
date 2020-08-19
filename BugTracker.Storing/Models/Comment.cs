using System;
using BugTracker.Storing.Abstracts;

namespace BugTracker.Storing.Models
{
    public class Comment : EntityBase
    {
        public string Text { get; set; }
        public int CommenterID { get; set; }
        public int TicketID { get; set; }
        public DateTime Created { get; set; }

        public virtual User Commenter { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}