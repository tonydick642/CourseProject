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
    [Authorize(Roles = "Coach,Admin")]
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

            if (db.Coachs.Any(i => i.UserId == currentUserId))
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
        public IActionResult AddSession(int id)
        {
            var currentUserId = this.User.FindFirst
                (ClaimTypes.NameIdentifier).Value;
            var coachId = db.Coachs.FirstOrDefault
                (s => s.UserId == currentUserId).CoachId;
            int lessonId = id;

            return View();
        }
        public IActionResult SubmitSession(int id)
        {
            Session session = new Session();
            var currentUserId = this.User.FindFirst
                (ClaimTypes.NameIdentifier).Value;
            var coachId = db.Coachs.FirstOrDefault
                (s => s.UserId == currentUserId).CoachId;
            session.LessonId = id;
            int lessonId = id;


            return View("Index");

        }
        [HttpPost]
        public async Task<IActionResult> AddSession(Session session, int lessonId, int id)
        {
            var currentUserId = this.User.FindFirst
                (ClaimTypes.NameIdentifier).Value;
            var coachId = db.Coachs.FirstOrDefault
                (s => s.UserId == currentUserId).CoachId;
            //session.LessonId = id;
            //  var lessonVar = db.Lessons.FirstOrDefault
            //      (l => l.LessonId == lessonId).LessonId;

            session.LessonId = id;
            session.CoachId = coachId;

            db.Add(session);
            await db.SaveChangesAsync();
            return View("Index");
        }
        public async Task<IActionResult> PostProgressReport(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var allSwimmers = await db.Enrollments.Include
                (c => c.Session).Where(c => c.SessionId == id)
                .ToListAsync();
            if (allSwimmers == null)
            {
                return NotFound();
            }
            return View(allSwimmers);
        }
        
    }
}
