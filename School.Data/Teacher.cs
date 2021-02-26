using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School.Data
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

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
        public DepartmentName Department { get; set; }
        public virtual ICollection<Course> CourseList { get; set; }
        public Teacher()
        {
            CourseList = new HashSet<Course>();

        }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}