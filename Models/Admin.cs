﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string AdminEmail { get; set; }
        public string AdminRole { get; set; }
        public string AdminPassword { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
