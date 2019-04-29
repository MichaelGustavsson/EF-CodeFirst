using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TPH.Models
{
    public class CourseTrackerInitializer: DropCreateDatabaseAlways<CourseContext>
    {
        protected override void Seed(CourseContext context)
        {
            base.Seed(context);

            var instructor = new Instructor()
            {
                FirstName = "Michael",
                LastName = "Gustavsson",
                Email = "michael.gustavssson@softtech.se",
                MobilePhone = "111-2222222",
                IsActive = true,
                TaughtCourses = 382
            };

            var student = new Student()
            {
                FirstName = "Erik",
                LastName = "Nilsson",
                CompanyName = "Företaget",
                Email = "erik.nilsson@foretaget.se"
            };

            context.Person.Add(instructor);
            context.Person.Add(student);
            context.SaveChanges();
        }
    }
}