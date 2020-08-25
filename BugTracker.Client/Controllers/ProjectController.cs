using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BugTracker.Client.Models;
using BugTracker.Client.ObjectModels;

namespace BugTracker.Client.Controllers
{
    [Route("/[controller]/[action]")]
    public class ProjectController : Controller
    {
        public IActionResult Project()
        {
            //List<ProjectModel> p = new List<ProjectModel>
            var p = new ProjectViewModel();
            //var p0 = new ProjectModel() {Title = "p0", Description="This is hard"};
            var p0 = new ProjectModel();
            var p1 = new ProjectModel() {Title = "p1", Description="This is harder"};
            var p2 = new ProjectModel() {Title = "p2", Description="This is hardest"};
            p0.Title = "p0";
            p0.Description = "This is hard";

            p.Projects.Add(p0);
            p.Projects.Add(p1);
            p.Projects.Add(p2);
            return View("Project",p);
        }

        public IActionResult AddProject()
        {
            return View();
        }
        
    }
}