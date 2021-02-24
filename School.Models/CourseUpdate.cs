using School.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static School.Data.Course;

namespace School.Models
{
    public class CourseUpdate
    {
        [Display(Name="Id")]
        public int CourseId { get; set; }
        [Display(Name = "Name")]

        public string CourseName { get; set; }
        [Display(Name = "Department")]

        public NameOfDepartment CourseDepartment { get; set; }
        [Display(Name = "Teacher")]

        public List<Teacher> CourseTeacher { get; set; }
        [Display(Name = "Student")]

        public List<Student> CourseStudent { get; set; }




    }
}
