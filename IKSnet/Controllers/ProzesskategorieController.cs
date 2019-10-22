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
    public class ProzesskategorieController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prozesskategorie
        public ActionResult Index()
        {
            return View(db.Prozesskategories.ToList());
        }

        // GET: Prozesskategorie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prozesskategorie prozesskategorie = db.Prozesskategories.Find(id);
            if (prozesskategorie == null)
            {
                return HttpNotFound();
            }
            return View(prozesskategorie);
        }

        // GET: Prozesskategorie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prozesskategorie/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Bezeichnung")] Prozesskategorie prozesskategorie)
        {
            if (ModelState.IsValid)
            {
                db.Prozesskategories.Add(prozesskategorie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prozesskategorie);
        }

        // GET: Prozesskategorie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prozesskategorie prozesskategorie = db.Prozesskategories.Find(id);
            if (prozesskategorie == null)
            {
                return HttpNotFound();
            }
            return View(prozesskategorie);
        }

        // POST: Prozesskategorie/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Bezeichnung")] Prozesskategorie prozesskategorie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prozesskategorie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prozesskategorie);
        }

        // GET: Prozesskategorie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prozesskategorie prozesskategorie = db.Prozesskategories.Find(id);
            if (prozesskategorie == null)
            {
                return HttpNotFound();
            }
            return View(prozesskategorie);
        }

        // POST: Prozesskategorie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prozesskategorie prozesskategorie = db.Prozesskategories.Find(id);
            db.Prozesskategories.Remove(prozesskategorie);
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
