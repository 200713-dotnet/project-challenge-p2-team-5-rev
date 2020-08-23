using System;
using System.Collections.Generic;

namespace BugTracker.Storing.Models
{
    public partial class Users
    {
        public Users()
        {
            Comment = new HashSet<Comment>();
            Project = new HashSet<Project>();
            TicketDev = new HashSet<Ticket>();
            TicketSubmitter = new HashSet<Ticket>();
            TicketUpdater = new HashSet<Ticket>();
            UserProject = new HashSet<UserProject>();
        }

        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual UserRole Role { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Project> Project { get; set; }
        public virtual ICollection<Ticket> TicketDev { get; set; }
        public virtual ICollection<Ticket> TicketSubmitter { get; set; }
        public virtual ICollection<Ticket> TicketUpdater { get; set; }
        public virtual ICollection<UserProject> UserProject { get; set; }
    }
}
