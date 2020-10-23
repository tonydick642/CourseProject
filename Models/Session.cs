using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class Session
    {
        public int SessionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SeatsAvailable { get; set; }
        public DateTime DailyStartTime { get; set; }
        public int CoachId { get; set; }
        public Coach Coach { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<ProgressReport> ProgressReports { get; set; }
        
    }
}
