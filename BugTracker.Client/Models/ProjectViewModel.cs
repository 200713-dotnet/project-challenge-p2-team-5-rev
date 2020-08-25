using System.Collections.Generic;
using BugTracker.Client.ObjectModels;

namespace BugTracker.Client.Models
{
    public class ProjectViewModel
    {
        public ProjectViewModel()
        {
            Projects = new List<ProjectModel> ();

        }
        public List<ProjectModel> Projects {get; set;}


    }
}