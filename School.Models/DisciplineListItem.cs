using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static School.Data.Discipline;

namespace School.Models
{
    public class DisciplineListItem
    {
        [Display(Name = "ID")]
        public int DisciplineId { get; set; }
        public string StudentName { get; set; }
        public string DisciplineType { get; set; }

        [Display(Name = "Expelled")]
        public bool Expelled { get; set; }

        [Display(Name = "Comment")]
        public string Comment { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
