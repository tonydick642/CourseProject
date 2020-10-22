using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class Swimmer
    {
        public int SwimmerId { get; set; }
        public string SwimmerName { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<ProgressReport> ProgressReports { get; set; }
        public string Gender { get; set; }
        public int SwimmerPhone { get; set; } 
        public DateTime dateOfBirth { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
