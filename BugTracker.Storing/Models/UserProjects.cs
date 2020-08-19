using BugTracker.Storing.Abstracts;

namespace BugTracker.Storing.Models
{
    public class UserProjects : EntityBase
    {
        public int UserID { get; set; }
        public int ProjectID { get; set; }

        public virtual User User { get; set; }
        public virtual Project Project { get; set; }
    }
}