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
    public class BoatController : Controller
    {
        private DragonModelsContainer db = new DragonModelsContainer();

        //
        // GET: /Boat/

        public ActionResult Index()
        {
            return View(db.BoatSet.ToList());
        }

        //
        // GET: /Boat/Details/5

        public ActionResult Details(int id = 0)
        {
            Boat boat = db.BoatSet.Find(id);
            if (boat == null)
            {
                return HttpNotFound();
            }
            return View(boat);
        }

        //
        // GET: /Boat/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Boat/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Boat boat)
        {
            if (ModelState.IsValid)
            {
                db.BoatSet.Add(boat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(boat);
        }

        //
        // GET: /Boat/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Boat boat = db.BoatSet.Find(id);
            if (boat == null)
            {
                return HttpNotFound();
            }
            return View(boat);
        }

        //
        // POST: /Boat/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Boat boat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boat);
        }

        //
        // GET: /Boat/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Boat boat = db.BoatSet.Find(id);
            if (boat == null)
            {
                return HttpNotFound();
            }
            return View(boat);
        }

        //
        // POST: /Boat/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Boat boat = db.BoatSet.Find(id);
            db.BoatSet.Remove(boat);
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