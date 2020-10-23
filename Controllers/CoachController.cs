using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using CourseProject.Models;
using CourseProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            if(db.Coachs.Any(i=> i.UserId == currentUserId))
            {
                coach = db.Coachs.FirstOrDefault(i => i.UserId == currentUserId);
            }
            else
            {
                //coach.CoachName = currentUserId;
                coach.UserId = currentUserId;
            }
            return View(coach);
        }

        [HttpPost]
        public async Task<IActionResult> AddProfile(Coach coach)
        {
            var currentUserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (db.Coachs.Any(i => i.UserId == currentUserId))
            {
                var coachToUpdate = db.Coachs.FirstOrDefault(i => i.UserId == currentUserId);
                coachToUpdate.CoachName = coach.CoachName;
                coachToUpdate.CoachPhone = coach.CoachPhone; 
                db.Update(coachToUpdate);
            }
            else
            {
                coach.UserId = currentUserId;
                db.Add(coach);
            }
            await db.SaveChangesAsync();
            return View("Index");
        }

        public async Task<IActionResult> AllLesson()
        {
            var lesson = await db.Lessons.Include
                (c => c.Sessions).ToListAsync();
            return View(lesson);
        }
        public IActionResult AddSession()
        {
            return View();
        }
        public async Task<IActionResult> SubmitSession(int id)
        {
                       
            return View("Index");
            
        }
  
        
    }
}
