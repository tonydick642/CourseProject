using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public string SkillLevel { get; set; }
        public decimal LessonTuition { get; set; }
        public ICollection<Session> Sessions { get; set; }
    }
}
