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
    public class CitiesController : Controller
    {
        private Bus_TourEntities1 db = new Bus_TourEntities1();

        // GET: Cities
        public ActionResult Index()
        {
            try
            {
                var city = db.City.Include(p => p.Country1);
                return View(city.ToList());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Cities/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                City city = db.City.Find(id);
                if (city == null)
                {
                    return HttpNotFound();
                }
                return View(city);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Cities/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.Country_Id = new SelectList(db.Country, "Country_Id", "Country_Name");
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: Cities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "City_Id,City_name,Country_Id,City_short_descr")] City city, HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (upload != null)
                    {
                        string fileName = System.IO.Path.GetFileName(upload.FileName);
                        upload.SaveAs(Server.MapPath("~/Image/" + fileName));
                        db.City.Add(city);
                        city.City_Image_Name = fileName;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                ViewBag.Country_Id = new SelectList(db.Country, "Country_Id", "Country_Name", city.Country_Id);
                return View(city);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                City city = db.City.Find(id);
                if (city == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Country_Id = new SelectList(db.Country, "Country_Id", "Country_Name");
                return View(city);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "City_Id,City_name,Country,City_short_descr")] City city, HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (upload != null)
                    {
                        string fileName = System.IO.Path.GetFileName(upload.FileName);
                        upload.SaveAs(Server.MapPath("~/Image/" + fileName));
                        db.Entry(city).State = EntityState.Modified;
                        city.City_Image_Name = fileName;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                ViewBag.Country_Id = new SelectList(db.Country, "Country_Id", "Country_Name");
                return View(city);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Cities/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                City city = db.City.Find(id);
                if (city == null)
                {
                    return HttpNotFound();
                }
                return View(city);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                City city = db.City.Find(id);
                db.City.Remove(city);
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
