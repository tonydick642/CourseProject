using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class SwimSchoolDbContext : DbContext
    {
        public DbSet<Swimmer> Swimmers { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public SwimSchoolDbContext(DbContextOptions
            <SwimSchoolDbContext> options) : base(options)
        { }
    }
}
