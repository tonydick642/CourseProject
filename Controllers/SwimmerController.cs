using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CourseProject.Models;
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
        public async Task<IActionResult> AddProfile
            (Swimmer swimmer)
        {
            var currentUserId = this.User.FindFirst
                (ClaimTypes.NameIdentifier).Value;
            if (db.Swimmers.Any(i => i.UserId == currentUserId))
            {
                var swimmerToUpdate = db.Swimmers.FirstOrDefault
                    (i => i.UserId == currentUserId);
                swimmerToUpdate.SwimmerName = swimmer.SwimmerName;
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

        public async Task<IActionResult> EnrollSession(int id)
        {
            var currentUserId = this.User.FindFirst
                (ClaimTypes.NameIdentifier).Value;
            var swimmerId = db.Swimmers.FirstOrDefault
                (s => s.UserId == currentUserId).SwimmerId;
            Enrollment enrollment = new Enrollment
            {
                SessionId = id,
                SwimmerId = swimmerId
            };
            db.Add(enrollment);
            var session = await db.Sessions.FindAsync
                (enrollment.SessionId);
            session.SeatsAvailable--;
            await db.SaveChangesAsync();
            return View("Index");
        }
    }      
}
