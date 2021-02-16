using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolWebApi.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string name { get; set; }
        public enum Department
        {
            English = 1,
            Math,
            Science,
            SocialStudies, 
            WorldLanguages,
            Arts,
            PhysicalEducation
        }
    }
}