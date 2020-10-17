using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles = "Admin")]/*Role protection for the admin home page, if you havent added users/roles yet comment this out to access admin home*/
        public IActionResult Home() => View();

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
