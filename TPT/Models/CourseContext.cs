using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TPT.Models
{
    public class CourseContext: DbContext
    {
        public DbSet<Person> Person { get; set; }

        public CourseContext(): base("DefaultConnection")
        {

        }
    }
}