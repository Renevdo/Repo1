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
    public class PoolController : Controller
    {
        private DragonModelsContainer db = new DragonModelsContainer();

        //
        // GET: /Pool/

        public ActionResult Index()
        {
            return View(db.PoolSet.ToList());
        }

        //
        // GET: /Pool/Details/5

        public ActionResult Details(int id = 0)
        {
            Pool pool = db.PoolSet.Find(id);
            if (pool == null)
            {
                return HttpNotFound();
            }
            return View(pool);
        }

        //
        // GET: /Pool/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Pool/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pool pool)
        {
            if (ModelState.IsValid)
            {
                db.PoolSet.Add(pool);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pool);
        }

        //
        // GET: /Pool/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Pool pool = db.PoolSet.Find(id);
            if (pool == null)
            {
                return HttpNotFound();
            }
            return View(pool);
        }

        //
        // POST: /Pool/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pool pool)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pool).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pool);
        }

        //
        // GET: /Pool/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Pool pool = db.PoolSet.Find(id);
            if (pool == null)
            {
                return HttpNotFound();
            }
            return View(pool);
        }

        //
        // POST: /Pool/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pool pool = db.PoolSet.Find(id);
            db.PoolSet.Remove(pool);
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