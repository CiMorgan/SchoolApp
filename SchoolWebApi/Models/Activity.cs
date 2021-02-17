using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolWebApi.Models
{
    public class Activity
    {

        public enum Season
        {
            Fall = 1,
            Winter,
            Spring,
            Summer,
            AllYear
        }

        public enum Activities  
        {
            Football = 1,
            Soccer,
            Hockey,
            Robotics,
            Programming,
            Drama,
            Band
        }

        public int Id { get; set; }
        public Activities Name { get; set; }
        public Season Duration { get; set; }
        public int MyProperty { get; set; }

    }
}