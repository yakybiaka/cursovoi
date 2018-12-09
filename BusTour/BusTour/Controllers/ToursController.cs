using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusTour;
using BusTour.Models;
using MailKit.Net.Smtp;
using MimeKit;

namespace BusTour.Controllers
{
    public class ToursController : Controller
    {
        private Bus_TourEntities1 db = new Bus_TourEntities1();

        // GET: Tours
        public ActionResult Index()
        {
            var tour = db.Tour.Include(t => t.City).Include(t => t.Route);
            return View(tour.ToList());
        }

        // GET: Tours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tour.Find(id);
            Route route = db.Route.Find(tour.Route_Id);

            if (tour == null)
            {
                return HttpNotFound();
            }

            ViewBag.Places = db.Place_in_the_route
            .Where(x => x.Route_Id == route.Route_Id)
            .OrderBy(x => x.Number_of_Day);

            List<int> Places_ids = new List<int>();
            foreach (var p in ViewBag.Places)
            {
                Places_ids.Add(p.Place_Id);
            }

            ViewBag.Places_info = db.Place.Where(
            x => Places_ids.Contains(x.Place_Id));
            return View(tour);
        }

        // GET: Tours/Create
        public ActionResult Create()
        {
            ViewBag.City_Id = new SelectList(db.City, "City_Id", "City_name");
            ViewBag.Route_Id = new SelectList(db.Route, "Route_Id", "Route_Description");
            return View();
        }
        // POST: Tours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Tour_Id,Route_Id,City_Id,Tour_Cost,Tour_Duration,Date_of_Depature,Tour_Name,Tour_Image")] Tour tour, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null)
                {
                    string fileName = System.IO.Path.GetFileName(upload.FileName);
                    upload.SaveAs(Server.MapPath("~/Image/" + fileName));
                    db.Tour.Add(tour);
                    tour.Tour_Image_Name = "/Image/" + fileName;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.City_Id = new SelectList(db.City, "City_Id", "City_name", tour.City_Id);
            ViewBag.Route_Id = new SelectList(db.Route, "Route_Id", "Route_Description", tour.Route_Id);
            return View(tour);
        }


        // GET: Tours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tour.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            ViewBag.City_Id = new SelectList(db.City, "City_Id", "City_name", tour.City_Id);
            ViewBag.Route_Id = new SelectList(db.Route, "Route_Id", "Route_Description", tour.Route_Id);
            return View(tour);
        }

        // POST: Tours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Tour_Id,Route_Id,City_Id,Tour_Cost,Tour_Duration,Date_of_Depature,Tour_Name,Tour_Image")] Tour tour, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null)
                {
                    string fileName = System.IO.Path.GetFileName(upload.FileName);
                    upload.SaveAs(Server.MapPath("~/Image/" + fileName));
                    db.Entry(tour).State = EntityState.Modified;
                    tour.Tour_Image_Name = "/Image/" + fileName;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.City_Id = new SelectList(db.City, "City_Id", "City_name", tour.City_Id);
            ViewBag.Route_Id = new SelectList(db.Route, "Route_Id", "Route_Description", tour.Route_Id);
            return View(tour);
        }

        // GET: Tours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tour.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // POST: Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tour tour = db.Tour.Find(id);
            db.Tour.Remove(tour);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}

