using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int SwimmerId { get; set; }
        public Swimmer Swimmer { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
        public string ProgressReport { get; set; }
    }
}
