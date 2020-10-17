using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    [Authorize(Roles = "Swimmer,Admin")]
    public class SwimmerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
