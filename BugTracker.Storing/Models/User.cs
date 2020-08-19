using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BugTracker.Storing.Abstracts;

namespace BugTracker.Storing.Models
{
    public class User : EntityBase
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public string Password { get; set; }

        [Required]
        public int RoleID { get; set; }

        [ForeignKey("RoleID")]
        public virtual UserRole Role { get; set; }

        [InverseProperty("Submitter")]
        public virtual ICollection<Ticket> SubmittedTickets { get; set; }

        [InverseProperty("Dev")]
        public virtual ICollection<Ticket> AssignedTickets { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<UserProject> UserProjects { get; set; }
    }
}