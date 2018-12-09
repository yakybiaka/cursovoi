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
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult About()
        {
            try
            {
                ViewBag.Message = "Your application description page.";

                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Contact()
        {
            try
            {
                ViewBag.Message = "Your contact page.";

                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult Feedback(Tour model)
        {
            try
            {
                Emailer.Send(model.Email, model.Name, model.Tour_Name);
                return RedirectToAction("Index", "Tours");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}