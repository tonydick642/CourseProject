using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class Coach
    {
        public int CoachId { get; set; }
        public string CoachName { get; set; }
        public string CoachPhone { get; set; }
        public ICollection<Session> Sessions { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
