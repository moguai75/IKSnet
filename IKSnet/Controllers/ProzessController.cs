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
    public class ProzessController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prozess
        public ActionResult Index(int? id)
        {
            //Viewmodel erstellen
            var viewModel = new ProzessIndexData();
            viewModel.Prozesss = db.Prozesss
                .Include(i => i.Prozessaktivitaets)
                .Include(i => i.Prozesskategorie);
            //Anhand id die Prozessaktivitäten selektieren
            if (id != null)
            {
                ViewBag.ProzessID = id.Value;
                viewModel.Prozessaktivitaets = viewModel.Prozesss.Where(
                    i => i.ID == id.Value).Single().Prozessaktivitaets;
            }

            return View(viewModel);
        }


        // GET: Prozess/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prozess prozess = db.Prozesss.Find(id);
            if (prozess == null)
            {
                return HttpNotFound();
            }
            return View(prozess);
        }

        // GET: Prozess/Create
        public ActionResult Create()
        {
            ViewBag.ProzesskategorieID = new SelectList(db.Prozesskategories, "ID", "Bezeichnung");
            return View();
        }

        // POST: Prozess/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Titel,Beschreibung,ProzesskategorieID")] Prozess prozess)
        {
            if (ModelState.IsValid)
            {
                db.Prozesss.Add(prozess);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProzesskategorieID = new SelectList(db.Prozesskategories, "ID", "Bezeichnung", prozess.ProzesskategorieID);
            return View(prozess);
        }

        // GET: Prozess/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prozess prozess = db.Prozesss.Find(id);
            if (prozess == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProzesskategorieID = new SelectList(db.Prozesskategories, "ID", "Bezeichnung", prozess.ProzesskategorieID);
            return View(prozess);
        }

        // POST: Prozess/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Titel,Beschreibung,ProzesskategorieID")] Prozess prozess)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prozess).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProzesskategorieID = new SelectList(db.Prozesskategories, "ID", "Bezeichnung", prozess.ProzesskategorieID);
            return View(prozess);
        }

        // GET: Prozess/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prozess prozess = db.Prozesss.Find(id);
            if (prozess == null)
            {
                return HttpNotFound();
            }
            return View(prozess);
        }

        // POST: Prozess/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prozess prozess = db.Prozesss.Find(id);
            if (prozess.Prozessaktivitaets.Count != 0)
            {
                ViewBag.Message = "Löschung nicht möglich, es bestehen noch Abhängigkeiten";
                return View(prozess);
            }
            db.Prozesss.Remove(prozess);
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
