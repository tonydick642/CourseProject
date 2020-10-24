using CourseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.ViewModels
{
    public class CoachAddProgressReportViewModel
    {
        public string Report { get; set; }
        public int SessionId { get; set; }
        public int SeatsAvailable { get; set; }
        public string SkillLevel { get; set; }
        public Coach Coach { get; set; }
        public int CoachId { get; set; }
    }
}
