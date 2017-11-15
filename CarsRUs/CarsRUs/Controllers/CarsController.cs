using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarsRUs.Models;
using CarsRUs.DAL;
using System.Net;
using System.Data.Entity;

namespace CarsRUs.Controllers
{
    public class CarsController : Controller
    {
        CarOwnersContext db = new CarOwnersContext();

        // GET: lists
        public ActionResult Index()
        {
            return View(db.car.ToList());
        }

        // GET: Owners/AddOwner/5
        public ActionResult AddOwner(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarsOwner carowner = new CarsOwner();

            carowner.cars = db.car.Find(id);

            if (carowner.cars == null)
            {
                return HttpNotFound();
            }

            if (carowner.cars.ownerID != null)
            {
                return RedirectToAction("CarOwned", "Cars");
            }

            return View(carowner);
        }


        // POST: Owners/AddOwner
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOwner(CarsOwner carsowner)
        {
            if (ModelState.IsValid)
            {
                var entity = new Owners() { ownerFirstName = carsowner.owner.ownerFirstName, ownerLastName = carsowner.owner.ownerLastName };

                db.owner.Add(entity);

                db.SaveChanges();

                int newOwner = (int)entity.ownerID;

                using (db)
                {
                    // make sure you have the right column/variable used here
                    var cars = db.car.FirstOrDefault(x => x.carID == carsowner.cars.carID);

                    if (cars == null) throw new Exception("Invalid id: " + carsowner.cars.carID);

                    // this variable is tracked by the db context
                    cars.ownerID = newOwner;

                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            return View(carsowner);
        }

        // GET: Cars
        public ActionResult CarOwned()
        {
            return View();
        }

        // GET: Owners/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarsOwner carowner = new CarsOwner();

            carowner.cars = db.car.Find(id);
            

            if (carowner.cars == null)
            {
                return HttpNotFound();
            }

            if (carowner.cars.ownerID == null)
            {
                return RedirectToAction("AddOwner", "Cars", id);
            
            }

            carowner.owner = db.owner.Find(carowner.cars.ownerID);

            return View(carowner);
        }

        // GET: Owners/AddOwner/5
        public ActionResult UpdateOwner(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarsOwner carowner = new CarsOwner();

            carowner.cars = db.car.Find(id);
          

            if (carowner.cars == null)
            {
                return HttpNotFound();
            }

            if (carowner.cars.ownerID == null)
            {
                return RedirectToAction("AddOwner", "Cars", id);

            }

            carowner.owner = db.owner.Find(carowner.cars.ownerID);

            return View(carowner);
        }

        // POST: Owners/AddOwner
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateOwner(CarsOwner carsowner)
        {
            if (ModelState.IsValid)
            {
                var entity = new Owners() { ownerFirstName = carsowner.owner.ownerFirstName, ownerLastName = carsowner.owner.ownerLastName };

                db.owner.Add(entity);

                db.SaveChanges();

                int newOwner = (int)entity.ownerID;

                using (db)
                {
                    // make sure you have the right column/variable used here
                    var cars = db.car.FirstOrDefault(x => x.carID == carsowner.cars.carID);

                    if (cars == null) throw new Exception("Invalid id: " + carsowner.cars.carID);

                    // this variable is tracked by the db context
                    cars.ownerID = newOwner;

                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            return View(carsowner);
        }
    }
}