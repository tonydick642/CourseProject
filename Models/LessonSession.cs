using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class LessonSession
    {
        public int LessonSessionId { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
        public int CoachId { get; set; }
        public Coach Coach { get; set; }
    }
}
