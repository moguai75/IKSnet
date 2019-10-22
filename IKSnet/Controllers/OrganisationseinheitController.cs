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
    public class OrganisationseinheitController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Organisationseinheit
        public ActionResult Index()
        {
            return View(db.Organisationseinheits.ToList());
        }

        // GET: Organisationseinheit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organisationseinheit organisationseinheit = db.Organisationseinheits.Find(id);
            if (organisationseinheit == null)
            {
                return HttpNotFound();
            }
            return View(organisationseinheit);
        }

        // GET: Organisationseinheit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Organisationseinheit/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Kurzbezeichnung,Bezeichnung")] Organisationseinheit organisationseinheit)
        {
            if (ModelState.IsValid)
            {
                db.Organisationseinheits.Add(organisationseinheit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(organisationseinheit);
        }

        // GET: Organisationseinheit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organisationseinheit organisationseinheit = db.Organisationseinheits.Find(id);
            if (organisationseinheit == null)
            {
                return HttpNotFound();
            }
            return View(organisationseinheit);
        }

        // POST: Organisationseinheit/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Kurzbezeichnung,Bezeichnung")] Organisationseinheit organisationseinheit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organisationseinheit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(organisationseinheit);
        }

        // GET: Organisationseinheit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organisationseinheit organisationseinheit = db.Organisationseinheits.Find(id);
            if (organisationseinheit == null)
            {
                return HttpNotFound();
            }
            return View(organisationseinheit);
        }

        // POST: Organisationseinheit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organisationseinheit organisationseinheit = db.Organisationseinheits.Find(id);
            db.Organisationseinheits.Remove(organisationseinheit);
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
