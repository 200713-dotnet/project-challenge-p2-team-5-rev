using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BugTracker.Storing.Abstracts;

namespace BugTracker.Storing.Models
{
    public class Ticket : EntityBase
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public int DevID { get; set; }

        [Required]
        public int SubmitterID { get; set; }

        [Required]
        public int ProjectID { get; set; }

        [Required]
        public int PriorityID { get; set; }

        [Required]
        public int StatusID { get; set; }

        [Required]
        public int TypeID { get; set; }

        [ForeignKey("DevID")]
        public virtual User Dev { get; set; }

        [ForeignKey("SubmitterID")]
        public virtual User Submitter { get; set; }

        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }

        [ForeignKey("PriorityID")]
        public virtual TicketPriority Priority { get; set; }

        [ForeignKey("StatusID")]
        public virtual TicketStatus Status { get; set; }

        [ForeignKey("TypeID")]
        public virtual TicketType Type { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}