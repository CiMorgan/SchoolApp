using School.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{
    public class CourseItemsDetail
    {
        //api/Activity/{id} Returns a specific activity’s Id, name, grade level, courses, extracurricular activities, and discipline record.
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Display(Name = "Department Name")]
        public string Department { get; set; }

        [Display(Name = "Teacher List")]
        public List<string> TeacherList { get; set; }
        [Display(Name = "List of Student")]
        public List<string> StudentList { get; set; }
    }
}
