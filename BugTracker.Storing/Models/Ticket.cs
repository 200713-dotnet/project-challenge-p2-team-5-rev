using System;
using System.Collections.Generic;
using BugTracker.Storing.Abstracts;

namespace BugTracker.Storing.Models
{
    public class Ticket : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public int DevID { get; set; }
        public int UbmitterID { get; set; }
        public int ProjectID { get; set; }
        public int PriorityID { get; set; }
        public int StatusID { get; set; }
        public int TypeID { get; set; }

        public virtual User Dev { get; set; }
        public virtual User Submitter { get; set; }
        public virtual Project Project { get; set; }
        public virtual TicketPriority Priority { get; set; }
        public virtual TicketStatus Status { get; set; }
        public virtual TicketType Type { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}