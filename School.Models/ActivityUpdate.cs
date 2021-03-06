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
    public class ActivityUpdate
    {
        [Display(Name="Id")]
        public int ActivityId { get; set; }

        [Display(Name = "Name")]
        public NameOfActivity ActivityName { get; set; }
      

        [Display(Name = "Duration")]
        public Season ActivityDuration { get; set; }
        

        [Display(Name = "TeacherId")]
        public int ActivityTeacherId { get; set; }

        [Display(Name = "LeadTeacher")]
        public Teacher ActivityLeadTeacher { get; set; }

        //[Display(Name = "StudentList")]
        //public List<string> ActivityStudentList { get; set; }
    }
}
