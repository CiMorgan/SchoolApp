using School.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{
    public class CourseItems
    {
        //api/Activity/{id} Returns a specific activity’s Id, name, grade level, courses, extracurricular activities, and discipline record.
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        
        [Display(Name = "Course Department")]
        public string CourseDepartment { get; set; }

        [Display(Name = "Course Teacher")]
        public string CourseTeacher { get; set; }
    }
}
