using System;
using System.Collections.Generic;

namespace BugTracker.Storing.Models
{
    public partial class TicketStatus
    {
        public TicketStatus()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int StatusId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
