﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static School.Data.Discipline;

namespace School.Models
{
    public class DisciplineEdit
    {
        public int DisciplineId { get; set; }
        public string Comment { get; set; }
        public TypeOfDiscipline DisciplineType { get; set; }
        public bool Expelled { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
