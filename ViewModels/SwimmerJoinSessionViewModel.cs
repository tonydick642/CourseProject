using CourseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.ViewModels
{
    public class SwimmerJoinSessionViewModel
    {
        public int SwimmerId { get; set; }
        public string SwimmerName { get; set; }
        public Enrollment Enrollment { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int SessionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SeatsAvailable { get; set; }
        public DateTime DailyStartTime { get; set; }
        public int CoachId { get; set; }
        public Coach Coach { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public string SkillLevel { get; set; }
        public decimal Tuition { get; set; }
        public Session Session { get; set; }

    }
}
