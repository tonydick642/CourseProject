using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using CourseProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    [Authorize(Roles ="Coach,Admin")]
    public class CoachController : Controller
    {
        private readonly SwimSchoolDbContext db;
        
        public CoachController(SwimSchoolDbContext db)
        { this.db = db; }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddProfile()
        {
            var currentUserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            Coach coach = new Coach();

            if(db.Coachs.Any(i=> i.CoachName == currentUserId))
            {
                coach = db.Coachs.FirstOrDefault(i => i.CoachName == currentUserId);
            }
            else
            {
                coach.CoachName = currentUserId;
            }
            return View(coach);
        }

        [HttpPost]
        public async Task<IActionResult> AddProfile(Coach coach)
        {
            var currentUserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if(db.Coachs.Any(i=>  i.CoachName == currentUserId))
            {
                var coachToUpdate = db.Coachs.FirstOrDefault(i => i.CoachName == currentUserId);
                coachToUpdate.CoachName = coach.CoachName;
                coachToUpdate.CoachPhone = coach.CoachPhone; ;
                db.Update(coachToUpdate);
            }
            else
            {
                db.Add(coach);
            }
            await db.SaveChangesAsync();
            return View("Index");
        }

        public IActionResult AddSession()
        {
            Session session = new Session();
            return View();
        }
    }
}
