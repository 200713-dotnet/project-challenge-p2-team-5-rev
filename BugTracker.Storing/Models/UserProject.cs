using System;
using System.Collections.Generic;

namespace BugTracker.Storing.Models
{
    public partial class UserProject
    {
        public int UserId { get; set; }
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
        public virtual Users User { get; set; }
    }
}
