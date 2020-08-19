using System.Collections.Generic;
using BugTracker.Storing.Abstracts;

namespace BugTracker.Storing.Models
{
    public class Project : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TicketID { get; set; }
        public int ManagerID { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual User Manager { get; set; }
    }
}