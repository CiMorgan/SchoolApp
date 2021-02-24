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
    public class CourseCreate
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public NameOfDepartment Department { get; set; }

        public List<Teacher> TeacherList { get; set; }

        public List<Student> StudentList { get; set; }



    }
}
