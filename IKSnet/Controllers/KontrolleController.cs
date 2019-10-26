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
    public class KontrolleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Aktive Kontrolle
        public ActionResult Index()
        {
            var kontrolles = db.Kontrolles.Include(k => k.ApplicationUser).Include(k => k.Organisationseinheit).Include(k => k.Risiko).Where(k => k.Status < KontrollStatus.Inaktiv);
            return View(kontrolles.ToList());
        }

        // GET: Erledigte Kontrolle
        public ActionResult ErledigtIndex()
        {
            var kontrolles = db.Kontrolles.Include(k => k.ApplicationUser).Include(k => k.Organisationseinheit).Include(k => k.Risiko).Where(k => k.Status == KontrollStatus.Inaktiv);
            return View(kontrolles.ToList());
        }

        // GET: Kontrolle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kontrolle kontrolle = db.Kontrolles.Find(id);
            if (kontrolle == null)
            {
                return HttpNotFound();
            }
            return View(kontrolle);
        }

        // GET: Kontrolle/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserID = new SelectList(db.Users, "Id", "BenutzerName");
            ViewBag.OrganisationseinheitID = new SelectList(db.Organisationseinheits, "ID", "Bezeichnung");
            ViewBag.RisikoID = new SelectList(db.Risikos, "ID", "Titel");
            return View();
        }

        // POST: Kontrolle/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Titel,Beschreibung,ApplicationUserID,OrganisationseinheitID,RisikoID,Start,Ende,KontrollFrequenz,KontrollArt,Status")] Kontrolle kontrolle)
        {
            if (ModelState.IsValid)
            {
                db.Kontrolles.Add(kontrolle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserID = new SelectList(db.Users, "Id", "BenutzerName", kontrolle.ApplicationUserID);
            ViewBag.OrganisationseinheitID = new SelectList(db.Organisationseinheits, "ID", "Kurzbezeichnung", kontrolle.OrganisationseinheitID);
            ViewBag.RisikoID = new SelectList(db.Risikos, "ID", "Titel", kontrolle.RisikoID);
            return View(kontrolle);
        }

        // GET: Kontrolle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kontrolle kontrolle = db.Kontrolles.Find(id);
            if (kontrolle == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserID = new SelectList(db.Users, "Id", "BenutzerName", kontrolle.ApplicationUserID);
            ViewBag.OrganisationseinheitID = new SelectList(db.Organisationseinheits, "ID", "Bezeichnung", kontrolle.OrganisationseinheitID);
            ViewBag.RisikoID = new SelectList(db.Risikos, "ID", "Titel", kontrolle.RisikoID);
            return View(kontrolle);
        }

        // POST: Kontrolle/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Titel,Beschreibung,ApplicationUserID,OrganisationseinheitID,RisikoID,Start,Ende,KontrollFrequenz,KontrollArt,Status")] Kontrolle kontrolle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kontrolle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserID = new SelectList(db.Users, "Id", "BenutzerName", kontrolle.ApplicationUserID);
            ViewBag.OrganisationseinheitID = new SelectList(db.Organisationseinheits, "ID", "Kurzbezeichnung", kontrolle.OrganisationseinheitID);
            ViewBag.RisikoID = new SelectList(db.Risikos, "ID", "Titel", kontrolle.RisikoID);
            return View(kontrolle);
        }

        // GET: Kontrolle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kontrolle kontrolle = db.Kontrolles.Find(id);
            if (kontrolle == null)
            {
                return HttpNotFound();
            }
            return View(kontrolle);
        }

        // POST: Kontrolle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kontrolle kontrolle = db.Kontrolles.Find(id);
            if (kontrolle.Aufgabes.Count != 0)
            {
                ViewBag.Message = "Löschung nicht möglich, es bestehen noch Abhängigkeiten";
                return View(kontrolle);
            }
            db.Kontrolles.Remove(kontrolle);
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
