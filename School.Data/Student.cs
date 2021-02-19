using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace School.Data
{
    public class Student
    {

        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        //attribute on gradelevel
        public int GradeLevel { get; set; }

        public virtual ICollection<Activity> ActivityList { get; set; }
        public virtual ICollection<Course> CourseList { get; set; }
        public virtual ICollection<Discipline> DisciplineList { get; set; }

        public Student()
        {
            ActivityList = new HashSet<Activity>();
            CourseList = new HashSet<Course>();
            DisciplineList = new HashSet<Discipline>();
        }
    }
}