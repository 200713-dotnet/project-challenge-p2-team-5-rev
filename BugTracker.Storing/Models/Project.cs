using System;
using System.Collections.Generic;

namespace BugTracker.Storing.Models
{
    public partial class Project
    {
        public Project()
        {
            Tickets = new HashSet<Ticket>();
            UserProjects = new HashSet<UserProject>();
        }

        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? ManagerId { get; set; }

        public virtual Users Manager { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<UserProject> UserProjects { get; set; }
    }
}
