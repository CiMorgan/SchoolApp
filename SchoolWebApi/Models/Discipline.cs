using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolWebApi.Models
{
    public class Discipline
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public bool Expelled  { get; set; }
        public enum Type
        {
            Detention = 1,
            InSchoolSuspension,
            OutOfSchoolSuspension,
            Expulsion,
        }
    }
}