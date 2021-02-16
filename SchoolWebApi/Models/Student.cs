using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolWebApi.Models
{
    public class Student
    {
        public enum LevelOfGrade
        {
            Ninth,         
            Tenth,
            Eleventh,
            Twelfth
        }

        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public LevelOfGrade GradeLevel { get; set; }
        public bool Expelled { get; set; }
        [ForeignKey("Activity")]
        public virtual int Activities { get; set; }
        [ForeignKey("Course")]
        public virtual int Courses { get; set; }
        [ForeignKey("Discipline")]
        public virtual int DisciplineRecord { get; set; }
    }
}