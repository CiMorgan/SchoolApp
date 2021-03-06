using School.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{
    public class ActivityItemsDetail
    {
        //api/Activity/{id} Returns a specific activity’s Id, name, grade level, courses, extracurricular activities, and discipline record.
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Activity Name")]
        public string ActivityName { get; set; }
        [Display(Name = "Lead Teacher")]
        public string LeadTeacher { get; set; }
        [Display(Name = "Season")]
        public string Duration { get; set; }
        [Display(Name = "List of Student")]
        public List<string> StudentList { get; set; }
    }
}
