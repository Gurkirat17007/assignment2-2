using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [Authorize]
    public class SportsController : Controller
    {
        // private Model1 db = new Model1();
        private ISportsMock db;

        // default constructor, use the live db
        public SportsController()
        {
            this.db = new EFSports();
        }

        // mock constructor
        public SportsController(ISportsMock mock)
        {
            this.db = mock;
        }
        // GET: Sports
        public ActionResult Index()
        {
            var sports = db.Sports.Include(s => s.Boys);
             return View(db.Sports.ToList());
        }

        //// GET: Sports/Details/5
       // [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");
            }
            //Sport sport = db.Sports.Find(id);
            Sport sport = db.Sports.SingleOrDefault(a => a.Boys == id);

            if (sport == null)
            {
                //return HttpNotFound();
                return View("Error");
            }
            return View("Details",sport);
        }

        //// GET: Sports/Create
        public ActionResult Create()
        {
            ViewBag.Boys = new SelectList(db.Sports, "Boys", "Girls");
            return View();
        }

        //// POST: Sports/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Boys,Soccer,Baseball,Rugby")] Sport sport)
        {
            if (ModelState.IsValid)
            {
                // db.Sports.Add(sport);
                // db.SaveChanges();
                db.Save(sport);
                return RedirectToAction("Index");
            }

            ViewBag.Boys = new SelectList(db.Sports, "Boys", "Girls", sport.Boys);
            return View("Create",sport);
        }

        //// GET: Sports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");
            }
            // Sport sport = db.Sports.Find(id);
            Sport sport = db.Sports.SingleOrDefault(a => a.Boys == id);

            if (sport == null)
            {
                // return HttpNotFound();
                return View("Error");
            }
            ViewBag.Boys = new SelectList(db.Sports, "Boys", "Girls", sport.Boys);
            return View("Edit",sport);
        }

        //// POST: Sports/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Boys,Soccer,Baseball,Rugby")] Sport sport)
        {
            if (ModelState.IsValid)
            {
               // db.Entry(sport).State = EntityState.Modified;
                db.Save(sport);
                return RedirectToAction("Index");
            }
            return View(sport);
        }

        //// GET: Sports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");
            }
            // Sport sport = db.Sports.Find(id);
            Sport sport = db.Sports.SingleOrDefault(a => a.Boys == id);

            if (sport == null)
            {
                // return HttpNotFound();
                return View("Error");
            }
            return View("Delete",sport);
        }

        //// POST: Sports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Sport sport = db.Sports.Find(id);
            // db.Sports.Remove(sport);
            // db.SaveChanges();
            if (id == null)
            {
                return View("Error");
            }

           Sport sport = db.Sports.SingleOrDefault(a => a.Boys == id);

            if (sport == null)
            {
                return View("Error");
            }

            db.Delete(sport);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
