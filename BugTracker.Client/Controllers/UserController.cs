using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BugTracker.Client.Models;

namespace BugTracker.Client.Controllers
{
    [Route("/[controller]/[action]")]
    public class UserController : Controller
    {
        public IActionResult UserPage()
        {
            return View();
        }

    }
}