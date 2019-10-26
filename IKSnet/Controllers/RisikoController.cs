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
    public class RisikoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Risiko
        public ActionResult Index()
        {
            var risikos = db.Risikos.Include(r => r.Prozessaktivitaet).Include(r => r.Risikokategorie);
            return View(risikos.ToList());
        }

        // GET: Risiko/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Risiko risiko = db.Risikos.Find(id);
            if (risiko == null)
            {
                return HttpNotFound();
            }
            return View(risiko);
        }

        // GET: Risiko/Create
        public ActionResult Create()
        {
            ViewBag.ProzessaktivitaetID = new SelectList(db.Prozessaktivitaets, "ID", "ID");
            ViewBag.RisikokategorieID = new SelectList(db.Risikokategories, "ID", "Bezeichnung");
            return View();
        }

        // POST: Risiko/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Titel,Risikobeschreibung,Eintrittswahrscheinlichkeit,Schadenausmass,Bewertung,ProzessaktivitaetID,RisikokategorieID")] Risiko risiko)
        {
            if (ModelState.IsValid)
            {
                //Enum in int
                var riskeintritt = risiko.Eintrittswahrscheinlichkeit;
                int valueeintritt = (int)riskeintritt;
                var riskschaden = risiko.Schadenausmass;
                int valueschaden = (int)riskschaden;
                //Berechnung Risikobewertung
                risiko.Bewertung = valueeintritt + valueschaden;
                db.Risikos.Add(risiko);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProzessaktivitaetID = new SelectList(db.Prozessaktivitaets, "ID", "ID", risiko.ProzessaktivitaetID);
            ViewBag.RisikokategorieID = new SelectList(db.Risikokategories, "ID", "Bezeichnung", risiko.RisikokategorieID);
            return View(risiko);
        }

        // GET: Risiko/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Risiko risiko = db.Risikos.Find(id);
            if (risiko == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProzessaktivitaetID = new SelectList(db.Prozessaktivitaets, "ID", "ID", risiko.ProzessaktivitaetID);
            ViewBag.RisikokategorieID = new SelectList(db.Risikokategories, "ID", "Bezeichnung", risiko.RisikokategorieID);
            return View(risiko);
        }

        // POST: Risiko/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Titel,Risikobeschreibung,Eintrittswahrscheinlichkeit,Schadenausmass,Bewertung,ProzessaktivitaetID,RisikokategorieID")] Risiko risiko)
        {
            if (ModelState.IsValid)
            {
                //Enum in int
                var riskeintritt = risiko.Eintrittswahrscheinlichkeit;
                int valueeintritt = (int)riskeintritt;
                var riskschaden = risiko.Schadenausmass;
                int valueschaden = (int)riskschaden;
                //Berechnung Risikobewertung
                risiko.Bewertung = valueeintritt + valueschaden;
                db.Entry(risiko).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProzessaktivitaetID = new SelectList(db.Prozessaktivitaets, "ID", "ID", risiko.ProzessaktivitaetID);
            ViewBag.RisikokategorieID = new SelectList(db.Risikokategories, "ID", "Bezeichnung", risiko.RisikokategorieID);
            return View(risiko);
        }

        // GET: Risiko/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Risiko risiko = db.Risikos.Find(id);
            if (risiko == null)
            {
                return HttpNotFound();
            }
            return View(risiko);
        }

        // POST: Risiko/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Risiko risiko = db.Risikos.Find(id);
            if (risiko.Kontrolles.Count != 0)
            {
                ViewBag.Message = "Löschung nicht möglich, es bestehen noch Abhängigkeiten";
                return View(risiko);
            }
            db.Risikos.Remove(risiko);
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
