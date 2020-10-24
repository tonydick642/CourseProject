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
    [Authorize(Roles = "Swimmer,Admin")]
    public class SwimmerController : Controller
    {
        private readonly SwimSchoolDbContext db;
        public SwimmerController(SwimSchoolDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ViewReport()
        {
            var report = await db.ProgressReports.ToListAsync();
            return View(report);
        }

        public async Task<IActionResult> AllLesson()
        {
            var lesson = await db.Lessons.ToListAsync();
            return View(lesson);
        }
        public IActionResult AddProfile()
        {
            
            var currentUserId = this.User.FindFirst
                (ClaimTypes.NameIdentifier).Value;
            Swimmer swimmer = new Swimmer();
            if (db.Swimmers.Any(i => i.UserId == currentUserId))
            {
                swimmer = db.Swimmers.FirstOrDefault(i =>
                i.UserId == currentUserId);
            }
            else
            {
                swimmer.UserId = currentUserId;
            }

            return View(swimmer);
        }
        [HttpPost]
        public async Task<IActionResult> AddProfile(Swimmer swimmer)
        {
            var currentUserId = this.User.FindFirst
                (ClaimTypes.NameIdentifier).Value;
            
            if (db.Swimmers.Any(i => i.UserId == currentUserId))
            {
                var swimmerToUpdate = db.Swimmers.FirstOrDefault
                    (i => i.UserId == currentUserId);
                swimmerToUpdate.SwimmerName = swimmer.SwimmerName;
                swimmerToUpdate.SwimmerPhone = swimmer.SwimmerPhone;
                db.Update(swimmerToUpdate);
            }
            else
            {
                swimmer.UserId = currentUserId;
                db.Add(swimmer);
            }
            await db.SaveChangesAsync();
            return View("Index");
        }
        public async Task<IActionResult> AllSession()
        {
            var session = await db.Sessions.Include
                (c => c.Coach).ToListAsync();
            return View(session);
        }
        public IActionResult EnrollSession(int id)
        {
            return View("Index");
        }
        [HttpPost]
        public async Task<IActionResult> EnrollSession()
        {
            var currentUserId = this.User.FindFirst
                (ClaimTypes.NameIdentifier).Value;
            var swimmerId = db.Swimmers.FirstOrDefault
                (s => s.UserId == currentUserId).SwimmerId;

            //session.LessonId = id;
           // session.CoachId = coachId;


            //db.Add(Enrollment);
            await db.SaveChangesAsync();
            return View("Index");
        }



    }      
}
