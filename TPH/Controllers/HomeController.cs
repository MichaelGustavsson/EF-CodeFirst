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
            var q = from i in db.Person.OfType<Instructor>() select i;
            var result = q.ToList();
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