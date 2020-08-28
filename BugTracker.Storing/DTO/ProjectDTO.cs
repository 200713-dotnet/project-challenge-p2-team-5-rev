using System.Collections.Generic;
using BugTracker.Storing.Models;

namespace BugTracker.Storing.DTO
{
    public class ProjectDTO
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public UserDTO Manager { get; set; }
        public List<TicketDTO> Tickets { get; set; }
        public List<UserDTO> DevTeam { get; set; }

        public ProjectDTO() { }

        public ProjectDTO(Project project)
        {
            ProjectId = project.ProjectId;
            Title = project.Title;
            Description = project.Description;

            if (project.Manager != null)
            {
                Manager = new UserDTO(project.Manager);
            }


            Tickets = new List<TicketDTO>();
            foreach (var ticket in project.Tickets)
            {
                Tickets.Add(new TicketDTO(ticket));
            }

            DevTeam = new List<UserDTO>();
            foreach (var user in project.UserProjects)
            {
                DevTeam.Add(new UserDTO(user.User));
            }
        }
    }
}