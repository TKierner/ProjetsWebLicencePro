using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetsWebLicencePro.Models;

namespace ProjetsWebLicencePro.Controllers
{
    public class realisationsController : Controller
    {
        private licence_mmiEntities2 db = new licence_mmiEntities2();

        // GET: realisations
        public ActionResult Index()
        {
            return View(db.realisation.ToList());
        }

        // GET: realisations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            realisation realisation = db.realisation.Find(id);
            if (realisation == null)
            {
                return HttpNotFound();
            }
            return View(realisation);
        }

        // GET: realisations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: realisations/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nom,description,createdAt")] realisation realisation)
        {
            if (ModelState.IsValid)
            {
                db.realisation.Add(realisation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(realisation);
        }

        // GET: realisations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            realisation realisation = db.realisation.Find(id);
            if (realisation == null)
            {
                return HttpNotFound();
            }
            return View(realisation);
        }

        // POST: realisations/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nom,description,createdAt")] realisation realisation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(realisation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(realisation);
        }

        // GET: realisations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            realisation realisation = db.realisation.Find(id);
            if (realisation == null)
            {
                return HttpNotFound();
            }
            return View(realisation);
        }

        // POST: realisations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            realisation realisation = db.realisation.Find(id);
            db.realisation.Remove(realisation);
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
