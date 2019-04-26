using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPH.Models;

namespace TPH.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new CourseContext();

            using (db)
            {
                var instructors = db.Person.ToList();
            }
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