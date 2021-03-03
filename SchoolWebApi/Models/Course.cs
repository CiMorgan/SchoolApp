using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolWebApi.Models
{
    public class Course
    {
        public enum DepartmentName
        {
            English = 1,
            Math,
            Science,
            SocialStudies,
            WorldLanguages,
            Art,
            PhysicalEducation
        }

        public int Id { get; set; }


        public string Name { get; set; }


        public DepartmentName Department { get; set; }


        public int TeacherList { get; set; }


        public int StudentList { get; set; }

        /* not sure if we will use this one
        public string Supplies { get; set; }
        */
    }
}