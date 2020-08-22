using System.Collections.Generic;

namespace BugTracker.Service.Models.Abstracts
{
    public abstract class TicketAttribute
    {
        public string Name { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}