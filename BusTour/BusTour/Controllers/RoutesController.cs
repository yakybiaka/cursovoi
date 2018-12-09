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
    public class RoutesController : Controller
    {
        private Bus_TourEntities1 db = new Bus_TourEntities1();

        // GET: Routes
        public ActionResult Index()
        {
            try
            {
                var route = db.Route.Include(r => r.Route_Type);
                return View(route.ToList());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Routes/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Route route = db.Route.Find(id);
                if (route == null)
                {
                    return HttpNotFound();
                }
                return View(route);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Routes/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.Id_Type_Route = new SelectList(db.Route_Type, "Id_Type_Route", "Route_Type1");
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: Routes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Route_Id,Id_Type_Route,Route_Duration,Route_Description")] Route route)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Route.Add(route);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.Id_Type_Route = new SelectList(db.Route_Type, "Id_Type_Route", "Route_Type1", route.Id_Type_Route);
                return View(route);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Routes/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Route route = db.Route.Find(id);
                if (route == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Id_Type_Route = new SelectList(db.Route_Type, "Id_Type_Route", "Route_Type1", route.Id_Type_Route);
                return View(route);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: Routes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Route_Id,Id_Type_Route,Route_Duration,Route_Description")] Route route)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(route).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Id_Type_Route = new SelectList(db.Route_Type, "Id_Type_Route", "Route_Type1", route.Id_Type_Route);
                return View(route);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Routes/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Route route = db.Route.Find(id);
                if (route == null)
                {
                    return HttpNotFound();
                }
                return View(route);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: Routes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Route route = db.Route.Find(id);
                db.Route.Remove(route);
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
