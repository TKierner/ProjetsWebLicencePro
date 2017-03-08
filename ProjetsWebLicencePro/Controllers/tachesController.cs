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
    public class tachesController : Controller
    {
        private licence_mmiEntities2 db = new licence_mmiEntities2();

        // GET: taches
        public ActionResult Index()
        {
            var tache = db.tache.Include(t => t.categorie).Include(t => t.projet);
            return View(tache.ToList());
        }

        // GET: taches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tache tache = db.tache.Find(id);
            if (tache == null)
            {
                return HttpNotFound();
            }
            return View(tache);
        }

        // GET: taches/Create
        public ActionResult Create()
        {
            ViewBag.Id_categorie = new SelectList(db.categorie, "Id", "label");
            ViewBag.Id_projet = new SelectList(db.projet, "Id", "nom");
            return View();
        }

        // POST: taches/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,description,Id_projet,valeur,startedAt,EndedAt,Id_categorie")] tache tache)
        {
            if (ModelState.IsValid)
            {
                db.tache.Add(tache);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_categorie = new SelectList(db.categorie, "Id", "label", tache.Id_categorie);
            ViewBag.Id_projet = new SelectList(db.projet, "Id", "nom", tache.Id_projet);
            return View(tache);
        }

        // GET: taches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tache tache = db.tache.Find(id);
            if (tache == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_categorie = new SelectList(db.categorie, "Id", "label", tache.Id_categorie);
            ViewBag.Id_projet = new SelectList(db.projet, "Id", "nom", tache.Id_projet);
            return View(tache);
        }

        // POST: taches/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,description,Id_projet,valeur,startedAt,EndedAt,Id_categorie")] tache tache)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tache).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_categorie = new SelectList(db.categorie, "Id", "label", tache.Id_categorie);
            ViewBag.Id_projet = new SelectList(db.projet, "Id", "nom", tache.Id_projet);
            return View(tache);
        }

        // GET: taches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tache tache = db.tache.Find(id);
            if (tache == null)
            {
                return HttpNotFound();
            }
            return View(tache);
        }

        // POST: taches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tache tache = db.tache.Find(id);
            db.tache.Remove(tache);
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
