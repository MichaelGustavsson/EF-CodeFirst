using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPH.Models
{
    public class Instructor: Person
    {
        public string MobilePhone { get; set; }
        public int TaughtCourses { get; set; }
        public bool IsActive { get; set; }

    }
}