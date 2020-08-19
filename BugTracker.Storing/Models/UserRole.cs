using System.Collections.Generic;
using BugTracker.Storing.Abstracts;

namespace BugTracker.Storing.Models
{
    public class UserRole : EntityBase
    {
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}