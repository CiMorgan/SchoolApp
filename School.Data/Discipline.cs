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
        public int DisciplineId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }
        public DateTime Date { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

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
        public DateTimeOffset CreatedUtc { get; set; }

        //public virtual ICollection<Student> StudentList { get; set; }

        //public Discipline()
        //{
        //    StudentList = new HashSet<Student>();
        //}
    }
}