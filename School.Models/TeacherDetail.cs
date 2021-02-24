using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{
    public class TeacherDetail
    {
        public int TeacherId { get; set; }
        [Display(Name = "ID")]
        public string TeacherName { get; set; }
        [Display(Name = "Teacher Name")]
        public List<string> TeacherDepartment { get; set; }
        [Display(Name = "Department")]
        public List<string> TeacherCourseList { get; set; }
        [Display(Name = "Courses Taught")]
        public List<string> TeacherActivityList { get; set; }
        [Display(Name = "Activity")]

        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Created")]

        public DateTimeOffset? ModifiedUtc { get; set; }
        [Display(Name = "Modified")]
    }
}
