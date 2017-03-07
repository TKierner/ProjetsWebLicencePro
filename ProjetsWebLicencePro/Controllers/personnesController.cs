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
    public class personnesController : Controller
    {
        private licence_mmiEntities db = new licence_mmiEntities();

        // GET: personnes
        public ActionResult Index()
        {
            var personne = db.personne.Include(p => p.entreprise).Include(p => p.promo);
            return View(personne.ToList());
        }

        // GET: personnes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personne personne = db.personne.Find(id);
            if (personne == null)
            {
                return HttpNotFound();
            }
            return View(personne);
        }

        // GET: personnes/Create
        public ActionResult Create()
        {
            ViewBag.Id_entreprise = new SelectList(db.entreprise, "Id", "nom");
            ViewBag.Id_promo = new SelectList(db.promo, "Id", "theme");
            return View();
        }

        // POST: personnes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,mail,pwd,prenom,nom,siteweb,parcours,birthdate,Id_promo,Id_entreprise")] personne personne)
        {
            if (ModelState.IsValid)
            {
                db.personne.Add(personne);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_entreprise = new SelectList(db.entreprise, "Id", "nom", personne.Id_entreprise);
            ViewBag.Id_promo = new SelectList(db.promo, "Id", "theme", personne.Id_promo);
            return View(personne);
        }

        // GET: personnes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personne personne = db.personne.Find(id);
            if (personne == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_entreprise = new SelectList(db.entreprise, "Id", "nom", personne.Id_entreprise);
            ViewBag.Id_promo = new SelectList(db.promo, "Id", "theme", personne.Id_promo);
            return View(personne);
        }

        // POST: personnes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,mail,pwd,prenom,nom,siteweb,parcours,birthdate,Id_promo,Id_entreprise")] personne personne)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personne).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_entreprise = new SelectList(db.entreprise, "Id", "nom", personne.Id_entreprise);
            ViewBag.Id_promo = new SelectList(db.promo, "Id", "theme", personne.Id_promo);
            return View(personne);
        }

        // GET: personnes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personne personne = db.personne.Find(id);
            if (personne == null)
            {
                return HttpNotFound();
            }
            return View(personne);
        }

        // POST: personnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            personne personne = db.personne.Find(id);
            db.personne.Remove(personne);
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
