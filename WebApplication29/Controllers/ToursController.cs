using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication29.Models;



namespace WebApplication29.Controllers
{
    public class ToursController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tours
        public ActionResult Index()
        {


            //IList<Tour> TourList = new List<Tour>() {
            //           new Tour() { TourID= 1,Tour_Name = "Ushaka" } ,
            //           new Tour() { TourID = 2, Tour_Name = "Robben_Island"} ,
            //           new Tour() { TourID = 3, Tour_Name = "Table_Mountain"} ,
            //           new Tour() { TourID = 4, Tour_Name = "Cape_Of_Good_Hope" } ,
            //           new Tour() { TourID = 5, Tour_Name = "Maclears_Beacon" }
            //};

            //var Index = from s in TourList
            //                    orderby s.Tour_Name descending
            //                    select s;

            //            var orderByDescendingResult = from s in TourList
            //                                          orderby s.Tour_Name descending
            //                                          select s;
            //// LINQ Query 
            //var myLinqQuery = from tour in db.Tours
            //                  where tour.Tour_Name.Contains('k')
            //                  select tour;

            //// Query execution
            //foreach (var tour in myLinqQuery)
            //    Console.Write(tour + "is available ");


            return View(db.Tours.ToList());
        }
        public ActionResult UserPage()
        {


          

            return View(db.Tours.ToList());
        }

        // GET: Tours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // GET: Tours/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TourID,TourType,Tour_Name,Tour_Duration,Num_Adults,Num_Kids,LocationFrom,TourDate,TourStartTime,Price,FriendlyMessage,Deposit,GuestCost,Total_Cost,TTickets")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                IList<Tour> TourList = new List<Tour>() {
                           new Tour() { TourID= 1,Tour_Name = "Ushaka" } ,
                           new Tour() { TourID = 2, Tour_Name = "Robben_Island"} ,
                           new Tour() { TourID = 3, Tour_Name = "Table_Mountain"} ,
                           new Tour() { TourID = 4, Tour_Name = "Cape_Of_Good_Hope" } ,
                           new Tour() { TourID = 5, Tour_Name = "Maclears_Beacon" },
                           ViewBag.TourName.tourname
            };

                var orderByResult = from s in TourList
                                    orderby s.Tour_Name descending
                                    select s;

                //var orderByDescendingResult = from s in TourList
                //                              orderby s.Tour_Name descending
                //                              select s;
                



                // LINQ Query 
                //var myLinqQuery = from Tour in db.Tours
                //                  where tour.Tour_Name.Contains('k')
                //                  select tour;

                //// Query execution
                //foreach (var Tour in myLinqQuery)
                //    Console.Write(tour + "is available ");

                db.Tours.Add(tour);
                db.SaveChanges();
                return RedirectToAction("UserPage");
            }

            return View(tour);
        }

        // GET: Tours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // POST: Tours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TourID,TourType,Tour_Name,Tour_Duration,Num_Adults,Num_Kids,LocationFrom,TourDate,TourStartTime,Price,FriendlyMessage,Deposit,GuestCost,Total_Cost,TTickets")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tour);
        }

        // GET: Tours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Find(id);
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
            Tour tour = db.Tours.Find(id);
            db.Tours.Remove(tour);
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
