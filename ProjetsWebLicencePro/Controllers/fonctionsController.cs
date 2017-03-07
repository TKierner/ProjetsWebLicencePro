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
    public class fonctionsController : Controller
    {
        private licence_mmiEntities db = new licence_mmiEntities();

        // GET: fonctions
        public ActionResult Index()
        {
            return View(db.fonction.ToList());
        }

        // GET: fonctions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fonction fonction = db.fonction.Find(id);
            if (fonction == null)
            {
                return HttpNotFound();
            }
            return View(fonction);
        }

        // GET: fonctions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: fonctions/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,label")] fonction fonction)
        {
            if (ModelState.IsValid)
            {
                db.fonction.Add(fonction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fonction);
        }

        // GET: fonctions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fonction fonction = db.fonction.Find(id);
            if (fonction == null)
            {
                return HttpNotFound();
            }
            return View(fonction);
        }

        // POST: fonctions/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,label")] fonction fonction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fonction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fonction);
        }

        // GET: fonctions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fonction fonction = db.fonction.Find(id);
            if (fonction == null)
            {
                return HttpNotFound();
            }
            return View(fonction);
        }

        // POST: fonctions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fonction fonction = db.fonction.Find(id);
            db.fonction.Remove(fonction);
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
