using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School.Data
{
    public class Course
    {
        //public enum DepartmentName
        //{
        //    English = 1,
        //    Math,
        //    Science,
        //    SocialStudies,
        //    WorldLanguages,
        //    Art,
        //    PhysicalEducation
        //}
        [Key]
        public int Id { get; set; }


        public string Name { get; set; }


        //public DepartmentName Department { get; set; }

        public virtual ICollection<Teacher> TeacherList { get; set; }
        public virtual ICollection<Student> StudentList { get; set; }

        public Course()
        {
            TeacherList = new HashSet<Teacher>();
            StudentList = new HashSet<Student>();
        }



        /* not sure if we will use this one
        public string Supplies { get; set; }
        */
    }
}