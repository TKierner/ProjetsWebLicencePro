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
    public class projetsController : Controller
    {
        private licence_mmiEntities db = new licence_mmiEntities();

        // GET: projets
        public ActionResult Index()
        {
            var projet = db.projet.Include(p => p.entreprise).Include(p => p.promo);
            return View(projet.ToList());
        }

        // GET: projets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            projet projet = db.projet.Find(id);
            if (projet == null)
            {
                return HttpNotFound();
            }
            return View(projet);
        }

        // GET: projets/Create
        public ActionResult Create()
        {
            ViewBag.Id_entreprise = new SelectList(db.entreprise, "Id", "nom");
            ViewBag.Id_promo = new SelectList(db.promo, "Id", "theme");
            return View();
        }

        // POST: projets/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nom,url,mail,description,logo,Id_entreprise,Id_promo")] projet projet)
        {
            if (ModelState.IsValid)
            {
                db.projet.Add(projet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_entreprise = new SelectList(db.entreprise, "Id", "nom", projet.Id_entreprise);
            ViewBag.Id_promo = new SelectList(db.promo, "Id", "theme", projet.Id_promo);
            return View(projet);
        }

        // GET: projets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            projet projet = db.projet.Find(id);
            if (projet == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_entreprise = new SelectList(db.entreprise, "Id", "nom", projet.Id_entreprise);
            ViewBag.Id_promo = new SelectList(db.promo, "Id", "theme", projet.Id_promo);
            return View(projet);
        }

        // POST: projets/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nom,url,mail,description,logo,Id_entreprise,Id_promo")] projet projet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_entreprise = new SelectList(db.entreprise, "Id", "nom", projet.Id_entreprise);
            ViewBag.Id_promo = new SelectList(db.promo, "Id", "theme", projet.Id_promo);
            return View(projet);
        }

        // GET: projets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            projet projet = db.projet.Find(id);
            if (projet == null)
            {
                return HttpNotFound();
            }
            return View(projet);
        }

        // POST: projets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            projet projet = db.projet.Find(id);
            db.projet.Remove(projet);
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
