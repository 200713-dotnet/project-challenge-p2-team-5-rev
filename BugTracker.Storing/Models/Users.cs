using System;
using System.Collections.Generic;

namespace BugTracker.Storing.Models
{
    public partial class Users
    {
        public Users()
        {
            Comments = new HashSet<Comment>();
            ManagedProjects = new HashSet<Project>();
            AssignedTickets = new HashSet<Ticket>();
            SubmittedTickets = new HashSet<Ticket>();
            UpdatedTickets = new HashSet<Ticket>();
            UserProjects = new HashSet<UserProject>();
        }

        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual UserRole Role { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Project> ManagedProjects { get; set; }
        public virtual ICollection<Ticket> AssignedTickets { get; set; }
        public virtual ICollection<Ticket> SubmittedTickets { get; set; }
        public virtual ICollection<Ticket> UpdatedTickets { get; set; }
        public virtual ICollection<UserProject> UserProjects { get; set; }
    }
}
