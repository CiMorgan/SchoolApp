using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School.Data
{
    public class Discipline
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        //attribute on comment
        public string Comment { get; set; }
        public bool Expelled { get; set; }
        public enum TypeOfDiscipline
        {
            Detention = 1,
            InSchoolSuspension,
            OutOfSchoolSuspension,
            Expulsion
        }
        public TypeOfDiscipline DisciplineType { get; set; }

        public virtual ICollection<Student> StudentList { get; set; }

        public Discipline()
        {
            StudentList = new HashSet<Student>();
        }
    }
}