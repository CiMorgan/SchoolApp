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

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Department Name")]
        public DepartmentName Department { get; set; }

        [Display(Name = "Courses Taught")]
        public List<int> ListOfCourses { get; set; } = new List<int>();

        [Display(Name = "Activity")]
        public List<int> ActivityLead { get; set; } = new List<int>();

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
