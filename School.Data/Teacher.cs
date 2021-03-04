using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace School.Data
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        //Teacher name is used in services only 
        public string TeacherName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

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

       // [ForeignKey("TeacherList")]
        public virtual Teacher TeacherList { get; set; }
        public virtual ICollection<Course> CourseList { get; set; }
        public Teacher()
        {
            CourseList = new HashSet<Course>();
        }
    }
}