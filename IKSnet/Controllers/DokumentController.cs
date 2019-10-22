﻿using System;
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
    public class DokumentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Dokument
        public ActionResult Index()
        {
            return View(db.Dokuments.ToList());
        }

        // GET: Dokument/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dokument dokument = db.Dokuments.Find(id);
            if (dokument == null)
            {
                return HttpNotFound();
            }
            return View(dokument);
        }

        // GET: Dokument/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dokument/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Titel,Beschreibung,GueltigAb,GueltigBis,Link")] Dokument dokument)
        {
            if (ModelState.IsValid)
            {
                db.Dokuments.Add(dokument);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dokument);
        }

        // GET: Dokument/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dokument dokument = db.Dokuments.Find(id);
            if (dokument == null)
            {
                return HttpNotFound();
            }
            return View(dokument);
        }

        // POST: Dokument/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Titel,Beschreibung,GueltigAb,GueltigBis,Link")] Dokument dokument)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dokument).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dokument);
        }

        // GET: Dokument/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dokument dokument = db.Dokuments.Find(id);
            if (dokument == null)
            {
                return HttpNotFound();
            }
            return View(dokument);
        }

        // POST: Dokument/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dokument dokument = db.Dokuments.Find(id);
            db.Dokuments.Remove(dokument);
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