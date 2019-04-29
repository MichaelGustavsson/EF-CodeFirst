using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPT.Models;

namespace TPT.Controllers
{
    public class InstructorController : Controller
    {
        // GET: Instructor
        public ActionResult Index()
        {
            var db = new CourseContext();
            var result = db.Person.OfType<Instructor>().ToList();
            var instructors = result.ToList();

            return View(instructors);
        }
    }
}