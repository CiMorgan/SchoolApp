using School.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{
    public class StudentItemsDetail
    {
        //api/Student/{id} Returns a specific student’s Id, name, grade level, courses, extracurricular activities, and discipline record.
        [Display(Name = "Id")]
        public int StudentId { get; set; }
        [Display(Name = "Name")]
        public string StudentName { get; set; }
        [Display(Name = "Grade Level")]
        public int StudentGrade { get; set; }
        [Display(Name = "Courses")]
        public List<string> StudentCourses { get; set; }
        [Display(Name = "Activities")]
        public string StudentActivities { get; set; }
        [Display(Name = "Discipline")]
        public List<Discipline> StudentDiscipline { get; set; }
    }
}
