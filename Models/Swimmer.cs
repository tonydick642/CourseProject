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
    }
}
