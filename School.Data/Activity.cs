using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace School.Data
{
    public class Activity
    {

        public enum Season
        {
            Fall = 1,
            Winter,
            Spring,
            Summer,
            AllYear
        }

        public enum NameOfActivity
        {
            Football = 1,
            Soccer,
            Hockey,
            Robotics,
            Programming,
            Drama,
            Band
        }
        [Key]
        public int Id { get; set; }
        public NameOfActivity Name { get; set; }
        public Season Duration { get; set; }

        //[ForeignKey("Teacher")]
        //public int TeacherId { get; set; }
        //public virtual Teacher LeadTeacher { get; set; }

        public virtual ICollection<Student> StudentList { get; set; }

        public Activity()
        {
            StudentList = new HashSet<Student>();
        }

    }
}