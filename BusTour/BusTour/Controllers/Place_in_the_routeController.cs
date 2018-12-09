using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusTour;

namespace BusTour.Controllers
{
    public class Place_in_the_routeController : Controller
    {
        private Bus_TourEntities1 db = new Bus_TourEntities1();

        // GET: Place_in_the_route
        public ActionResult Index()
        {
            try
            {
                var place_in_the_route = db.Place_in_the_route.Include(p => p.Place).Include(p => p.Route);
                return View(place_in_the_route.ToList());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Place_in_the_route/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Place_in_the_route place_in_the_route = db.Place_in_the_route.Find(id);
                if (place_in_the_route == null)
                {
                    return HttpNotFound();
                }
                return View(place_in_the_route);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Place_in_the_route/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.Place_Id = new SelectList(db.Place, "Place_Id", "Place_short_descr");
                ViewBag.Route_Id = new SelectList(db.Route, "Route_Id", "Route_Description");
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: Place_in_the_route/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Place_in_the_route_Id,Place_Id,Route_Id,Number_of_Day,Day_Description")] Place_in_the_route place_in_the_route)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Place_in_the_route.Add(place_in_the_route);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.Place_Id = new SelectList(db.Place, "Place_Id", "Place_short_descr", place_in_the_route.Place_Id);
                ViewBag.Route_Id = new SelectList(db.Route, "Route_Id", "Route_Description", place_in_the_route.Route_Id);
                return View(place_in_the_route);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Place_in_the_route/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Place_in_the_route place_in_the_route = db.Place_in_the_route.Find(id);
                if (place_in_the_route == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Place_Id = new SelectList(db.Place, "Place_Id", "Place_short_descr", place_in_the_route.Place_Id);
                ViewBag.Route_Id = new SelectList(db.Route, "Route_Id", "Route_Description", place_in_the_route.Route_Id);
                return View(place_in_the_route);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: Place_in_the_route/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Place_in_the_route_Id,Place_Id,Route_Id,Number_of_Day,Day_Description")] Place_in_the_route place_in_the_route)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(place_in_the_route).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Place_Id = new SelectList(db.Place, "Place_Id", "Place_short_descr", place_in_the_route.Place_Id);
                ViewBag.Route_Id = new SelectList(db.Route, "Route_Id", "Route_Description", place_in_the_route.Route_Id);
                return View(place_in_the_route);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Place_in_the_route/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Place_in_the_route place_in_the_route = db.Place_in_the_route.Find(id);
                if (place_in_the_route == null)
                {
                    return HttpNotFound();
                }
                return View(place_in_the_route);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: Place_in_the_route/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Place_in_the_route place_in_the_route = db.Place_in_the_route.Find(id);
                db.Place_in_the_route.Remove(place_in_the_route);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
