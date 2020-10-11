using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult AddRole()
        {
            return View();
        }

        public IActionResult AllRole()
        {
            return View();
        }
    }
}
