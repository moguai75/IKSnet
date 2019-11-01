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
    public class ProzessaktivitaetController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prozessaktivitaet
        public ActionResult Index()
        {
            var prozessaktivitaets = db.Prozessaktivitaets.Include(p => p.Prozess);
            return View(prozessaktivitaets.ToList());
        }

        // GET: Prozessaktivitaet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prozessaktivitaet prozessaktivitaet = db.Prozessaktivitaets.Find(id);
            if (prozessaktivitaet == null)
            {
                return HttpNotFound();
            }
            return View(prozessaktivitaet);
        }

        // GET: Prozessaktivitaet/Create
        public ActionResult Create(int? id)
        {
            if (id != null)
            {
                ViewBag.ProzessID = new SelectList(db.Prozesss, "ID", "Titel", id.Value);
            }
            else
            {
                ViewBag.ProzessID = new SelectList(db.Prozesss, "ID", "Titel");
            }
                
            return View();
        }

        // POST: Prozessaktivitaet/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Sortierung,Titel,Beschreibung,ProzessID")] Prozessaktivitaet prozessaktivitaet)
        {
            if (ModelState.IsValid)
            {
                db.Prozessaktivitaets.Add(prozessaktivitaet);
                db.SaveChanges();
                return RedirectToAction("Index", "Prozess");
            }

            ViewBag.ProzessID = new SelectList(db.Prozesss, "ID", "Titel", prozessaktivitaet.ProzessID);
            return View(prozessaktivitaet);
        }

        // GET: Prozessaktivitaet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prozessaktivitaet prozessaktivitaet = db.Prozessaktivitaets.Find(id);
            if (prozessaktivitaet == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProzessID = new SelectList(db.Prozesss, "ID", "Titel", prozessaktivitaet.ProzessID);
            return View(prozessaktivitaet);
        }

        // POST: Prozessaktivitaet/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Sortierung,Titel,Beschreibung,ProzessID")] Prozessaktivitaet prozessaktivitaet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prozessaktivitaet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Prozess");
            }
            ViewBag.ProzessID = new SelectList(db.Prozesss, "ID", "Titel", prozessaktivitaet.ProzessID);
            return View(prozessaktivitaet);
        }

        // GET: Prozessaktivitaet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prozessaktivitaet prozessaktivitaet = db.Prozessaktivitaets.Find(id);
            if (prozessaktivitaet == null)
            {
                return HttpNotFound();
            }
            return View(prozessaktivitaet);
        }

        // POST: Prozessaktivitaet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prozessaktivitaet prozessaktivitaet = db.Prozessaktivitaets.Find(id);
            if (prozessaktivitaet.Risikos.Count != 0)
            {
                ViewBag.Message = "Löschung nicht möglich, es bestehen noch Abhängigkeiten";
                return View(prozessaktivitaet);
            }
            db.Prozessaktivitaets.Remove(prozessaktivitaet);
            db.SaveChanges();
            return RedirectToAction("Index", "Prozess");
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
