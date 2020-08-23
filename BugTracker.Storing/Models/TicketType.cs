using System;
using System.Collections.Generic;

namespace BugTracker.Storing.Models
{
    public partial class TicketType
    {
        public TicketType()
        {
            Ticket = new HashSet<Ticket>();
        }

        public int TypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
