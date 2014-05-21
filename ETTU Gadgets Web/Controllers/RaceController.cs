using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETTU_Gadgets_Web.Models;
using ETTU_Gadgets_Web.Models.ViewModels;

namespace ETTU_Gadgets_Web.Controllers
{
    public class RaceController : Controller
    {
        private DragonModelsContainer db = new DragonModelsContainer();

        //
        // GET: /Race/

        public ActionResult Index()
        {
            var raceset = db.RaceSet.Include(r => r.Pool);
            return View(raceset.ToList());
        }

        //
        // GET: /Race/Details/5

        public ActionResult Details(int id = 0)
        {
            Race race = db.RaceSet.Find(id);
            if (race == null)
            {
                return HttpNotFound();
            }
            return View(race);
        }

        //
        // GET: /Race/Create

        public ActionResult Create()
        {
            ViewBag.AvailableBoats = db.BoatSet;
            ViewBag.AvailablePools = new SelectList(db.PoolSet, "Id", "Name");
            return View();
        }

        //
        // POST: /Race/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RaceViewModel rvm)
        {
            Race race = rvm.Race;
            race.Boats.Add(db.BoatSet.Find(rvm.Boat1));
            race.Boats.Add(db.BoatSet.Find(rvm.Boat2));

            if (ModelState.IsValid)
            {
                db.RaceSet.Add(race);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AvailableBoats = db.BoatSet;
            ViewBag.AvailablePools = new SelectList(db.PoolSet, "Id", "Name", race.PoolId);
            return View(race);
        }

        //
        // GET: /Race/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Race race = db.RaceSet.Find(id);
            if (race == null)
            {
                return HttpNotFound();
            }
            ViewBag.PoolId = new SelectList(db.PoolSet, "Id", "Name", race.PoolId);
            return View(race);
        }

        //
        // POST: /Race/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Race race)
        {
            if (ModelState.IsValid)
            {
                db.Entry(race).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PoolId = new SelectList(db.PoolSet, "Id", "Name", race.PoolId);
            return View(race);
        }

        //
        // GET: /Race/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Race race = db.RaceSet.Find(id);
            if (race == null)
            {
                return HttpNotFound();
            }
            return View(race);
        }

        //
        // POST: /Race/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Race race = db.RaceSet.Find(id);
            db.RaceSet.Remove(race);
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