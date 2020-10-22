using CourseProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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

        SwimSchoolDbContext db;
        public AdminController(SwimSchoolDbContext db)
        {
            this.db = db;
        }
        public IActionResult AddLesson()
        {
            return View();

        }       

        public async Task<IActionResult> AllLesson()
        {
            var lesson = await db.Lessons.ToListAsync();
            return View(lesson);
        }

    }
}
