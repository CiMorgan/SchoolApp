using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolWebApi.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
    }
}