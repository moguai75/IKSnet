using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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
            var aufgabes = db.Aufgabes.Include(a => a.ApplicationUser).Include(a => a.Kontrolle).Where(a => a.Status < AufgabeStatus.Abgeschlossen);
            return View(aufgabes.ToList());
        }


        public ActionResult ErledigtIndex()
        {
            var aufgabes = db.Aufgabes.Include(a => a.ApplicationUser).Include(a => a.Kontrolle).Where(a => a.Status == AufgabeStatus.Abgeschlossen);
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
        public ActionResult Create(int? id)
        {
            ViewBag.ApplicationUserID = new SelectList(db.Users, "Id", "BenutzerName");

            var kont = db.Kontrolles.Select(k => new
            {
                ID = k.ID,
                KoTitel = k.ID + " - " + k.Titel,
            }).ToList();
            //Selektieren der Kontrolle im Dopdown falls aus der Detailansicht Kontrolle gestartet
            if (id == null)
            {
                ViewBag.KontrolleID = new SelectList(kont, "ID", "KoTitel");
            }
            else
            {
                ViewBag.KontrolleID = new SelectList(kont, "ID", "KoTitel", id);
            }
            return View();
        }

        // POST: Aufgabe/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Titel,Beschreibung,Faellig,Status,KontrolleID,ApplicationUserID,Kommentar,Visum,Dokument,Erledigt")] Aufgabe aufgabe)
        {
            if (ModelState.IsValid)
            {
                db.Aufgabes.Add(aufgabe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserID = new SelectList(db.Users, "Id", "BenutzerName", aufgabe.ApplicationUserID);
            ViewBag.KontrolleID = new SelectList(db.Kontrolles, "ID", "Titel", aufgabe.KontrolleID);
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

            var kont = db.Kontrolles.Select(k => new
            {
                ID = k.ID,
                KoTitel = k.ID + " - " + k.Titel,
            }).ToList();

            ViewBag.KontrolleID = new SelectList(kont, "ID", "KoTitel", aufgabe.KontrolleID);
            return View(aufgabe);
        }

        // POST: Aufgabe/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Titel,Beschreibung,Faellig,Status,KontrolleID,ApplicationUserID,Kommentar,Dokument,Visum,Erledigt")] Aufgabe aufgabe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aufgabe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserID = new SelectList(db.Users, "Id", "BenutzerName", aufgabe.ApplicationUserID);
            ViewBag.KontrolleID = new SelectList(db.Kontrolles, "ID", "Titel", aufgabe.KontrolleID);
            return View(aufgabe);
        }


        public ActionResult CloseEdit(int? id)
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
            ViewBag.KontrolleID = new SelectList(db.Kontrolles, "ID", "Titel", aufgabe.KontrolleID);
            return View(aufgabe);
        }

        // POST: Aufgabe/Close/5
        //Abschliessen der Aufgabe durch den Mitarbeiter
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CloseEdit([Bind(Include = "ID,Titel,Beschreibung,Faellig,Status,KontrolleID,ApplicationUserID,Kommentar,Dokument,Visum,Erledigt")] Aufgabe aufgabe, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                //Prüfen, ob ein Dokument hinzugefügt werden soll
                if (upload != null && upload.ContentLength > 0)
                {
                    //Speicherung des Dokuments
                    try
                    {
                    string jahr = DateTime.Now.Year.ToString();
                    string monat = DateTime.Now.Month.ToString();
                    string day = DateTime.Now.Day.ToString();
                    string std = DateTime.Now.Hour.ToString();
                    string min = DateTime.Now.Minute.ToString();
                    string sek = DateTime.Now.Second.ToString();
                    string time = jahr + monat + day + std + min + sek;
                    string filename = time + "_" + System.IO.Path.GetFileName(upload.FileName);
                    aufgabe.Dokument = filename;
                    upload.SaveAs(System.Configuration.ConfigurationManager.AppSettings["AblageAufgabe"] + filename);
                    }
                    //Falls Speicherung nicht erfolgreich, Fehlermeldung ausgeben
                    catch
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Dokument konnte nicht gespeichert werden");
                    }

                }
                aufgabe.Status = AufgabeStatus.Abgeschlossen;
                aufgabe.Erledigt = DateTime.Now;
                db.Entry(aufgabe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserID = new SelectList(db.Users, "Id", "BenutzerName", aufgabe.ApplicationUserID);
            ViewBag.KontrolleID = new SelectList(db.Kontrolles, "ID", "Titel", aufgabe.KontrolleID);
            return View(aufgabe);
        }

        //Anzeigen eines hinzugefügten Dokuments nach Abschluss der Aufgabe.
        public ActionResult Show(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Selektion der Aufgabe über die id
            Aufgabe aufgabe = db.Aufgabes.Find(id);
            if (aufgabe == null)
            {
                return HttpNotFound();
            }
            var path = System.Configuration.ConfigurationManager.AppSettings["AblageAufgabe"];
            try
            {
                var fileStream = new FileStream(path + aufgabe.Dokument,
                                                 FileMode.Open,
                                                 FileAccess.Read
                                               );
                return File(fileStream, MimeMapping.GetMimeMapping(path + aufgabe.Dokument), aufgabe.Dokument);
            }
            catch
            {
                return RedirectToAction("Index");
            }
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
