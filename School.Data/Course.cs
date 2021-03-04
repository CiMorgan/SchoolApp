using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School.Data
{
    public class Course
    {
        public enum NameOfDepartment
        {
            English = 1,
            Math,
            Science,
            SocialStudies,
            WorldLanguages,
            Art,
            PhysicalEducation
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public NameOfDepartment Department { get; set; }

        public virtual ICollection<Teacher> TeacherList { get; set; }
        public virtual ICollection<Student> StudentList { get; set; }

        public Course()
        {
            TeacherList = new HashSet<Teacher>();
            StudentList = new HashSet<Student>();
        }
    }
}