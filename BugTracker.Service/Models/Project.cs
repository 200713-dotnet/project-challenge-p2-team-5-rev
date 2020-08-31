using System.Collections.Generic;

namespace BugTracker.Service.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public User Manager { get; set; }

        public List<Ticket> Tickets { get; set; }

        public List<User> DevTeam { get; set; }
    }
}