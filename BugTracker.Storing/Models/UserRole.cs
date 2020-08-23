using System;
using System.Collections.Generic;

namespace BugTracker.Storing.Models
{
    public partial class UserRole
    {
        public UserRole()
        {
            Users = new HashSet<Users>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
