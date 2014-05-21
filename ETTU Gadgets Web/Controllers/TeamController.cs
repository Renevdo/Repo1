using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETTU_Gadgets_Web.Models;
using ETTU_Gadgets_Web.Views.Shared;

namespace ETTU_Gadgets_Web.Controllers
{
    public class TeamController : Controller
    {
        private DragonModelsContainer db = new DragonModelsContainer();

        //
        // GET: /Team/

        public ActionResult Index(int id = 0)
        {
            Boat boat = db.BoatSet.Find(id);
            if (boat == null)
            {
                return HttpNotFound();
            }
            return View(boat);
        }

        //
        // GET: /Team/EditTeam/1

        public ActionResult EditTeam(int id = 0)
        {
            Boat boat = db.BoatSet.Find(id);
            if (boat == null)
            {
                return HttpNotFound();
            }
            return View(boat);
        }

        //
        // POST: /Team/EditTeam/1

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTeam(Boat boat)
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
        // GET: /Team/Details/5

        public ActionResult Details(int id = 0)
        {
            Person person = db.PersonSet.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        //
        // GET: /Team/Create

        public ActionResult Create()
        {
            ViewBag.BoatId = new SelectList(db.BoatSet, "Id", "Name");
            return View();
        }

        //
        // POST: /Team/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                db.PersonSet.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BoatId = new SelectList(db.BoatSet, "Id", "Name");
            return View(person);
        }

        //
        // GET: /Team/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Person person = db.PersonSet.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            ViewBag.BoatId = new SelectList(db.BoatSet, "Id", "Name", person.BoatId);
            return View(person);
        }

        //
        // POST: /Team/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person person, UploadImageModel viewModel)
        {
            if (viewModel.UploadImage != null && viewModel.UploadImage.ContentLength > 0)
            {
                byte[] buffer = new byte[viewModel.UploadImage.ContentLength];
                viewModel.UploadImage.InputStream.Read(buffer, 0, viewModel.UploadImage.ContentLength);
                person.Image = buffer;
            }

            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("EditTeam", new { id=person.BoatId });
            }
            ViewBag.BoatId = new SelectList(db.BoatSet, "Id", "Name", person.BoatId);
            return View(person);
        }

        //
        // GET: /Team/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Person person = db.PersonSet.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        //
        // POST: /Team/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.PersonSet.Find(id);
            db.PersonSet.Remove(person);
            db.SaveChanges();
            return RedirectToAction("EditTeam", new { id = person.BoatId });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}