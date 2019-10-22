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
    public class AufgabeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Aufgabe
        public ActionResult Index()
        {
            var aufgabes = db.Aufgabes.Include(a => a.ApplicationUser);
            return View(aufgabes.ToList());
        }

        // GET: Aufgabe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aufgabe aufgabe = db.Aufgabes.Find(id);
            if (aufgabe == null)
            {
                return HttpNotFound();
            }
            return View(aufgabe);
        }

        // GET: Aufgabe/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserID = new SelectList(db.Users, "Id", "BenutzerName");
            return View();
        }

        // POST: Aufgabe/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Titel,Beschreibung,Faellig,Status,KontrollID,ApplicationUserID,Kommentar,Dokument")] Aufgabe aufgabe)
        {
            if (ModelState.IsValid)
            {
                db.Aufgabes.Add(aufgabe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserID = new SelectList(db.Users, "Id", "BenutzerName", aufgabe.ApplicationUserID);
            return View(aufgabe);
        }

        // GET: Aufgabe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aufgabe aufgabe = db.Aufgabes.Find(id);
            if (aufgabe == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserID = new SelectList(db.Users, "Id", "BenutzerName", aufgabe.ApplicationUserID);
            return View(aufgabe);
        }

        // POST: Aufgabe/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Titel,Beschreibung,Faellig,Status,KontrollID,ApplicationUserID,Kommentar,Dokument")] Aufgabe aufgabe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aufgabe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserID = new SelectList(db.Users, "Id", "BenutzerName", aufgabe.ApplicationUserID);
            return View(aufgabe);
        }

        // GET: Aufgabe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aufgabe aufgabe = db.Aufgabes.Find(id);
            if (aufgabe == null)
            {
                return HttpNotFound();
            }
            return View(aufgabe);
        }

        // POST: Aufgabe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aufgabe aufgabe = db.Aufgabes.Find(id);
            db.Aufgabes.Remove(aufgabe);
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
