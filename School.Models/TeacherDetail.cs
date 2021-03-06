﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static School.Data.Teacher;

namespace School.Models
{
    public class TeacherDetail
    {
        [Display(Name = "ID")]
        public int TeacherId { get; set; }

        [Display(Name = "Teacher Name")]
        public string TeacherName { get; set; }

        [Display(Name = "Department Name")]
        public string Department { get; set; }

        [Display(Name = "Courses Taught")]
        public List<string> TeacherCourse { get; set; }

        [Display(Name = "Activity")]
        public List<string> TeacherActivity { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
