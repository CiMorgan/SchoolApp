using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{
    public class ActivityUpdate
    {
        [Display(Name="Id")]
        public int ActivityId { get; set; }

        [Display(Name = "Name")]
        public int ActivityName { get; set; }

        [Display(Name = "Duration")]
        public int ActivityDuration { get; set; }

        [Display(Name = "TeacherId")]
        public int ActivityTeacherId { get; set; }

        [Display(Name = "LeadTeacher")]
        public int ActivityLeadTeacher { get; set; }

        [Display(Name = "StudentList")]
        public int ActivityStudentList { get; set; }
    }
}
