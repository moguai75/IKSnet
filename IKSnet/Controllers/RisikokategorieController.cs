using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IKSnet.Models;

namespace IKSnet.Controllers
{
    public class RisikokategorieController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Risikokategorie
        public ActionResult Index()
        {
            return View(db.Risikokategories.ToList());
        }

        // GET: Risikokategorie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Risikokategorie risikokategorie = db.Risikokategories.Find(id);
            if (risikokategorie == null)
            {
                return HttpNotFound();
            }
            return View(risikokategorie);
        }

        // GET: Risikokategorie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Risikokategorie/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Bezeichnung")] Risikokategorie risikokategorie)
        {
            if (ModelState.IsValid)
            {
                db.Risikokategories.Add(risikokategorie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(risikokategorie);
        }

        // GET: Risikokategorie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Risikokategorie risikokategorie = db.Risikokategories.Find(id);
            if (risikokategorie == null)
            {
                return HttpNotFound();
            }
            return View(risikokategorie);
        }

        // POST: Risikokategorie/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Bezeichnung")] Risikokategorie risikokategorie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(risikokategorie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(risikokategorie);
        }

        // GET: Risikokategorie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Risikokategorie risikokategorie = db.Risikokategories.Find(id);
            if (risikokategorie == null)
            {
                return HttpNotFound();
            }
            return View(risikokategorie);
        }

        // POST: Risikokategorie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Risikokategorie risikokategorie = db.Risikokategories.Find(id);
            //Check auf zugeordnete Risiken
            if (risikokategorie.Risikos.Count != 0)
            {
                ViewBag.Message = "Löschung nicht möglich, es bestehen noch Abhängigkeiten";
                return View(risikokategorie);
            }
            db.Risikokategories.Remove(risikokategorie);
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
