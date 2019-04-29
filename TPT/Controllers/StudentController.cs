using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPT.Models;

namespace TPT.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            var db = new CourseContext();
            var result = db.Person.OfType<Student>().ToList();
            var students = result.ToList();

            return View(students);
        }
    }
}