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
    public class carsController : Controller
    {
        //db connection moved to Models/EFcarRepository.cs
        //private Model1 db = new Model1();
        private IcarsRepository db;

        public carsController()
        {

            this.db = new EFcarsRepository();
        }

        // if we tell the controller we are testing, use the mock interface
        public carsController(IcarsRepository db)
        {

            this.db = db;

        }

        // GET: cars
        public ViewResult Index()
        {
            return View(db.cars.ToList());
        }

        [AllowAnonymous]
        // GET: cars/Details/5
        public ViewResult Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            car car = db.cars.FirstOrDefault(a => a.Price == id);
            if (car == null)
            {
                return View("Error");
            }
            return View(car);
        }

        //// GET: cars/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        ////// POST: cars/Create
        ////// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        ////// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        ////[HttpPost]
        ////[ValidateAntiForgeryToken]
        ////public ActionResult Create([Bind(Include = "Cars,Models,Price")] car car)
        ////{
        ////    if (ModelState.IsValid)
        ////    {
        ////        db.cars.Add(car);
        ////        db.SaveChanges();
        ////        return RedirectToAction("Index");
        ////    }

        ////    return View(car);
        ////}

        ////// GET: cars/Edit/5
        ////public ActionResult Edit(string id)
        ////{
        ////    if (id == null)
        ////    {
        ////        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        ////    }
        ////    car car = db.cars.Find(id);
        ////    if (car == null)
        ////    {
        ////        return HttpNotFound();
        ////    }
        ////    return View(car);
        ////}

        ////// POST: cars/Edit/5
        ////// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        ////// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        ////[HttpPost]
        ////[ValidateAntiForgeryToken]
        ////public ActionResult Edit([Bind(Include = "Cars,Models,Price")] car car)
        ////{
        ////    if (ModelState.IsValid)
        ////    {
        ////        db.Entry(car).State = EntityState.Modified;
        ////        db.SaveChanges();
        ////        return RedirectToAction("Index");
        ////    }
        ////    return View(car);
        ////}

        ////// GET: cars/Delete/5
        ////public ActionResult Delete(string id)
        ////{
        ////    if (id == null)
        ////    {
        ////        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        ////    }
        ////    car car = db.cars.Find(id);
        ////    if (car == null)
        ////    {
        ////        return HttpNotFound();
        ////    }
        ////    return View(car);
        ////}

        // POST: cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ViewResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }


            car car = db.cars.FirstOrDefault(a => a.Price == id);

            if (car == null)
            {
                return View("Error");

            }
            db.Delete(car);
            return View("Index");
        }

        ////protected override void Dispose(bool disposing)
        ////{
        ////    if (disposing)
        ////    {
        ////        db.Dispose();
        ////    }
        ////    base.Dispose(disposing);
        ////}
    }
}
