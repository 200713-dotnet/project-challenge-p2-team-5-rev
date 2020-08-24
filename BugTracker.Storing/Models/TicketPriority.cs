using System;
using System.Collections.Generic;

namespace BugTracker.Storing.Models
{
    public partial class TicketPriority
    {
        public TicketPriority()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int PriorityId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
