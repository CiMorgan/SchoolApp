﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{
    public class DisciplineListItem
    {
        [Display(Name = "ID")]
        public int DisciplineId { get; set; }
        public enum TypeOfDiscipline
        {
            Detention = 1,
            InSchoolSuspension,
            OutOfSchoolSuspension,
            Expulsion
        }
        public TypeOfDiscipline DisciplineType { get; set; }

        [Display(Name = "Comment")]
        public string Comment { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
