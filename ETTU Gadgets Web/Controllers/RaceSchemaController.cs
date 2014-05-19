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
    public class RaceSchemaController : Controller
    {
        private DragonModelsContainer db = new DragonModelsContainer();

        //
        // GET: /RaceSchema/

        public ActionResult Index()
        {
            return View(db.RaceSchemaSet.ToList());
        }

        //
        // GET: /RaceSchema/Details/5

        public ActionResult Details(int id = 0)
        {
            RaceSchema raceschema = db.RaceSchemaSet.Find(id);
            if (raceschema == null)
            {
                return HttpNotFound();
            }
            return View(raceschema);
        }

        //
        // GET: /RaceSchema/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /RaceSchema/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RaceSchema raceschema)
        {
            if (ModelState.IsValid)
            {
                db.RaceSchemaSet.Add(raceschema);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(raceschema);
        }

        //
        // GET: /RaceSchema/Edit/5

        public ActionResult Edit(int id = 0)
        {
            RaceSchema raceschema = db.RaceSchemaSet.Find(id);
            if (raceschema == null)
            {
                return HttpNotFound();
            }
            return View(raceschema);
        }

        //
        // POST: /RaceSchema/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RaceSchema raceschema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(raceschema).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(raceschema);
        }

        //
        // GET: /RaceSchema/Delete/5

        public ActionResult Delete(int id = 0)
        {
            RaceSchema raceschema = db.RaceSchemaSet.Find(id);
            if (raceschema == null)
            {
                return HttpNotFound();
            }
            return View(raceschema);
        }

        //
        // POST: /RaceSchema/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RaceSchema raceschema = db.RaceSchemaSet.Find(id);
            db.RaceSchemaSet.Remove(raceschema);
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