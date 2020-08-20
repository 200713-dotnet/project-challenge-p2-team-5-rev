using System.Collections.Generic;
using BugTracker.Service.Models.Abstracts;

namespace BugTracker.Service.Models
{
    public class Project : EntityBase
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int ManagerID { get; set; } // probably not needed

        public virtual User Manager { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<UserProject> UserProjects { get; set; }
    }
}