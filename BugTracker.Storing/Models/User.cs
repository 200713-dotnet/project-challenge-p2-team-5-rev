using System.Collections.Generic;
using BugTracker.Storing.Abstracts;

namespace BugTracker.Storing.Models
{
    public class User : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }

        public virtual UserRole Role { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}