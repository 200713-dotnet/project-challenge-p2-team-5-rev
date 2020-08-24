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
        public IActionResult Product()
        {
            //List<ProjectModel> p = new List<ProjectModel>
            var p = new ProjectViewModel();
            
            p.Projects.Add(new ProjectModel {Title = "p0", Description="This is hard"});
            p.Projects.Add(new ProjectModel {Title = "p1", Description="This is harder"});
            p.Projects.Add(new ProjectModel {Title = "p2", Description="This is hardest"});
            return View("Project",p);
        }
        
    }
}