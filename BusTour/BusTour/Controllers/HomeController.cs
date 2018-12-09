using BusTour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusTour.Controllers
{
    public class HomeController : Controller
    {
        private Bus_TourEntities1 db = new Bus_TourEntities1();

        public ActionResult Index()
        {
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

        [HttpPost]
        public ActionResult Feedback(Tour model)
        {
           Emailer.Send(model.Email);
           return RedirectToAction("Index", "Tours");
        }
    }
}