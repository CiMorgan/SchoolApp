using School.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static School.Data.Activity;

namespace School.Models
{
    public class ActivityCreate
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public NameOfActivity Name { get; set; }

        public Season Duration { get; set; }

        public int TeacherId { get; set; }

        //public List<Teacher> LeadTeacher { get; set; }
        public Teacher LeadTeacher { get; set; }

        public ICollection<Student> StudentList { get; set; }





    }
}
