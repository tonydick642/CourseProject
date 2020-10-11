using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class CoachController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
