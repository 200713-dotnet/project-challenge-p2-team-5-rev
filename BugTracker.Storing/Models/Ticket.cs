using System;
using System.Collections.Generic;

namespace BugTracker.Storing.Models
{
    public partial class Ticket
    {
        public Ticket()
        {
            Comments = new HashSet<Comment>();
        }

        public int TicketId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? DevId { get; set; }
        public int SubmitterId { get; set; }
        public int? UpdaterId { get; set; }
        public int ProjectId { get; set; }
        public int PriorityId { get; set; }
        public int StatusId { get; set; }
        public int TypeId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public virtual Users Dev { get; set; }
        public virtual TicketPriority Priority { get; set; }
        public virtual Project Project { get; set; }
        public virtual TicketStatus Status { get; set; }
        public virtual Users Submitter { get; set; }
        public virtual TicketType Type { get; set; }
        public virtual Users Updater { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
