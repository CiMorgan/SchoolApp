﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{
    public class DisciplineCreate
    {
        [Required]
        public int DisciplineId { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}
