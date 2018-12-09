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
    public class PlacesController : Controller
    {
        private Bus_TourEntities1 db = new Bus_TourEntities1();

        // GET: Places
        public ActionResult Index()
        {
            try
            {
                var place = db.Place.Include(p => p.Place_Type).Include(p => p.City);
                return View(place.ToList());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Places/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Place place = db.Place.Find(id);
                if (place == null)
                {
                    return HttpNotFound();
                }
                return View(place);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Places/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.Type_Place_Id = new SelectList(db.Place_Type, "Type_Place_Id", "Place_Type1");
                ViewBag.City_Id = new SelectList(db.City, "City_Id", "City_name");
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: Places/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Place_Id,City_Id,Type_Place_Id,Place_short_descr")] Place place, HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (upload != null)
                    {
                        string fileName = System.IO.Path.GetFileName(upload.FileName);
                        upload.SaveAs(Server.MapPath("~/Image/" + fileName));
                        place.Place_Image_Name = fileName;
                        db.Place.Add(place);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                ViewBag.Type_Place_Id = new SelectList(db.Place_Type, "Type_Place_Id", "Place_Type1", place.Type_Place_Id);
                return View(place);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Places/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Place place = db.Place.Find(id);
                if (place == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Type_Place_Id = new SelectList(db.Place_Type, "Type_Place_Id", "Place_Type1", place.Type_Place_Id);
                ViewBag.City_Id = new SelectList(db.City, "City_Id", "City_name", place.City_Id);
                return View(place);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: Places/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Place_Id,City_Id,Type_Place_Id,Place_short_descr")] Place place, HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (upload != null)
                    {
                        string fileName = System.IO.Path.GetFileName(upload.FileName);
                        upload.SaveAs(Server.MapPath("~/Image/" + fileName));
                        db.Entry(place).State = EntityState.Modified;
                        place.Place_Image_Name = fileName;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                ViewBag.Type_Place_Id = new SelectList(db.Place_Type, "Type_Place_Id", "Place_Type1", place.Type_Place_Id);
                return View(place);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Places/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Place place = db.Place.Find(id);
                if (place == null)
                {
                    return HttpNotFound();
                }
                return View(place);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: Places/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Place place = db.Place.Find(id);
                db.Place.Remove(place);
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
