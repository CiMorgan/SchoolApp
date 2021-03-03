using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static School.Data.Teacher;

namespace School.Models
{
    public class TeacherEdit
    {
        [Display(Name = "ID")]
        public int TeacherId { get; set; }

        [Display(Name = "Teacher Name")]
        public string TeacherName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public DepartmentName Department { get; set; }

        [Display(Name = "Courses Taught")]
        public List<string> TeacherCourseList { get; set; }

        [Display(Name = "Activity")]
        public List<string> TeacherActivityList { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
