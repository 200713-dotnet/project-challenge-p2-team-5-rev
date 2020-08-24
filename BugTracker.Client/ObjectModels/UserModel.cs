using System.Collections.Generic;

namespace BugTracker.Client.ObjectModels
{
    public class UserModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }

        public int RoleID { get; set; } // not sure

        //public virtual UserRole Role { get; set; }
        public string UserRole {get; set;}
        
        //public virtual ICollection<Ticket> SubmittedTickets { get; set; }

        //public virtual ICollection<Ticket> AssignedTickets { get; set; }

        //public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<ProjectModel> UserProjects { get; set; }
    }
}