using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BugTracker.Storing.Abstracts;

namespace BugTracker.Storing.Models
{
    public class Project : EntityBase
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int ManagerID { get; set; }

        [ForeignKey("MangerID")]
        public virtual User Manager { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<UserProject> UserProjects { get; set; }
    }
}