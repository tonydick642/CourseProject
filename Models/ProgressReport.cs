using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class ProgressReport
    {
        public int ProgressReportId { get; set; }
        public int SwimmerId { get; set; }
        public Swimmer Swimmer { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
        public string Report { get; set; }

        
    }
}
