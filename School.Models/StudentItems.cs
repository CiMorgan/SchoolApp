using School.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{
    public class StudentItems
    {
        //api/Student Returns all students' id, name, and grade level
        [Display(Name = "Id")]
        public int StudentId { get; set; }
        [Display(Name = "Name")]
        public string StudentName { get; set; }
        [Display(Name = "Grade Level")]
        public int StudentGrade { get; set; }
    }
}
