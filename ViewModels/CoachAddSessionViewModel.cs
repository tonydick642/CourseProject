using CourseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CourseProject.ViewModels
{
    public class CoachAddSessionViewModel
    {
        public ApplicationUser User { get; set; }
        public string SkillLevel { get; set; }
        public int SessionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SeatsAvailable { get; set; }
        public DateTime DailyStartTime { get; set; }
        public int CoachId { get; set; }
        
        public int LessonId { get; set; }
        public Coach Coach { get; set; }
        public Lesson Lesson { get; set; }
        public LessonSession lessonSession { get; set; }
        public Session session { get; set; }
        
        

    }
}
