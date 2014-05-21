using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETTU_Gadgets_Web.Models;

namespace ETTU_Gadgets_Web.Controllers
{
    public class RaceResultController : Controller
    {
        private DragonModelsContainer db = new DragonModelsContainer();

        //
        // GET: /RaceResult/

        public ActionResult Index()
        {
            var raceresultset = db.RaceResultSet.Include(r => r.Race).Include(r => r.Boat);
            return View(raceresultset.ToList());
        }

        //
        // GET: /RaceResult/Details/5

        public ActionResult Details(int id = 0)
        {
            RaceResult raceresult = db.RaceResultSet.Find(id);
            if (raceresult == null)
            {
                return HttpNotFound();
            }
            return View(raceresult);
        }

        //
        // GET: /RaceResult/Create

        public ActionResult Create()
        {
            ViewBag.RaceId = new SelectList(db.RaceSet, "Id", "Pool");
            ViewBag.BoatId = new SelectList(db.BoatSet, "Id", "Name");
            return View();
        }

        //
        // POST: /RaceResult/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RaceResult raceresult)
        {
            if (ModelState.IsValid)
            {
                db.RaceResultSet.Add(raceresult);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RaceId = new SelectList(db.RaceSet, "Id", "Pool", raceresult.RaceId);
            ViewBag.BoatId = new SelectList(db.BoatSet, "Id", "Name", raceresult.BoatId);
            return View(raceresult);
        }

        //
        // GET: /RaceResult/Edit/5

        public ActionResult Edit(int id = 0)
        {
            RaceResult raceresult = db.RaceResultSet.Find(id);
            if (raceresult == null)
            {
                return HttpNotFound();
            }
            ViewBag.RaceId = new SelectList(db.RaceSet, "Id", "Pool", raceresult.RaceId);
            ViewBag.BoatId = new SelectList(db.BoatSet, "Id", "Name", raceresult.BoatId);
            return View(raceresult);
        }

        //
        // POST: /RaceResult/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RaceResult raceresult)
        {
            if (ModelState.IsValid)
            {
                db.Entry(raceresult).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RaceId = new SelectList(db.RaceSet, "Id", "Pool", raceresult.RaceId);
            ViewBag.BoatId = new SelectList(db.BoatSet, "Id", "Name", raceresult.BoatId);
            return View(raceresult);
        }

        //
        // GET: /RaceResult/Delete/5

        public ActionResult Delete(int id = 0)
        {
            RaceResult raceresult = db.RaceResultSet.Find(id);
            if (raceresult == null)
            {
                return HttpNotFound();
            }
            return View(raceresult);
        }

        //
        // POST: /RaceResult/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RaceResult raceresult = db.RaceResultSet.Find(id);
            db.RaceResultSet.Remove(raceresult);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}