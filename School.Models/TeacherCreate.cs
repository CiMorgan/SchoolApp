using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static School.Data.Teacher;

namespace School.Models
{
    public class TeacherCreate
    {
        [Required]
        public int TeacherId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public DepartmentName Department { get; set; }
        public List<string> TeacherActivity { get; set; }
    }
}
