using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BugTracker.Storing.Abstracts;

namespace BugTracker.Storing.Models
{
    public class Comment : EntityBase
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public int CommenterID { get; set; }

        [Required]
        public int TicketID { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [ForeignKey("CommenterID")]
        public virtual User Commenter { get; set; }

        [ForeignKey("TicketID")]
        public virtual Ticket Ticket { get; set; }
    }
}