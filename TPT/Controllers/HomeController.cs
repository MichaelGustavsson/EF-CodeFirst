using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPT.Models;

namespace TPT.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new CourseContext();

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

            db.Person.Add(instructor);
            db.Person.Add(student);
            db.SaveChanges();

            // var q = from i in db.Person.OfType<Instructor>() select i;
            // var result = q.ToList();
            var result = db.Person.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}