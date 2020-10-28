using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class SwimSchoolDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Swimmer> Swimmers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Coach> Coachs { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Session> Sessions { get; set; }

        public SwimSchoolDbContext(DbContextOptions
            <SwimSchoolDbContext> options) : base(options)
        { }
    }
}
