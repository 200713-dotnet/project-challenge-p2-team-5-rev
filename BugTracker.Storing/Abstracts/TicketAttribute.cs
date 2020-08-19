using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BugTracker.Storing.Models;

namespace BugTracker.Storing.Abstracts
{
    public abstract class TicketAttribute : EntityBase
    {
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}