using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// references

namespace Ass2.Models
{
    public class EFcarsRepository : IcarsRepository
    {
        // repository for CRUD with cars in SQL Server db

        // db connection moved  here from carsController
        Model1 db = new Model1();

        public IQueryable<car> cars { get { return db.cars; } }

        public void Delete(car car)
        {
            db.cars.Remove(car);
            db.SaveChanges();
        }

        public car save(car car)
        {
            if (car.Price == 0)
            {

                db.cars.Add(car);

            }
            else
            {

                db.Entry(car).State = System.Data.Entity.EntityState.Modified;

            }

            db.SaveChanges();
            return car;
        }
    }
}