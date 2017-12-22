using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ass2.Models;

namespace Ass2.Controllers
{
    [Authorize]
    public class cars_2Controller : Controller
    {
        private Model1 db = new Model1();

        // GET: cars_2
        public ActionResult Index()
        {
            var cars_2 = db.cars_2.Include(c => c.car);
            return View(cars_2.ToList());
        }

        // GET: cars_2/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cars_2 cars_2 = db.cars_2.Find(id);
            if (cars_2 == null)
            {
                return HttpNotFound();
            }
            return View(cars_2);
        }

        // GET: cars_2/Create
        public ActionResult Create()
        {
            ViewBag.Cars = new SelectList(db.cars, "Cars", "Models");
            return View();
        }

        // POST: cars_2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehNo,Cars,RentalCost")] cars_2 cars_2)
        {
            if (ModelState.IsValid)
            {
                db.cars_2.Add(cars_2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cars = new SelectList(db.cars, "Cars", "Models", cars_2.Cars);
            return View(cars_2);
        }

        // GET: cars_2/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cars_2 cars_2 = db.cars_2.Find(id);
            if (cars_2 == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cars = new SelectList(db.cars, "Cars", "Models", cars_2.Cars);
            return View(cars_2);
        }

        // POST: cars_2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehNo,Cars,RentalCost")] cars_2 cars_2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cars_2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cars = new SelectList(db.cars, "Cars", "Models", cars_2.Cars);
            return View(cars_2);
        }

        // GET: cars_2/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cars_2 cars_2 = db.cars_2.Find(id);
            if (cars_2 == null)
            {
                return HttpNotFound();
            }
            return View(cars_2);
        }

        // POST: cars_2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            cars_2 cars_2 = db.cars_2.Find(id);
            db.cars_2.Remove(cars_2);
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
