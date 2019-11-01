using IKSnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;

namespace IKSnet.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //Daten aufbereiten für Dashboard Home
        public ActionResult Index()
        {
            //ViewModel erstellen
            var viewModelHome = new HomeIndexData();
            viewModelHome.Risikokategories = db.Risikokategories;
            viewModelHome.Risikos = db.Risikos;
            viewModelHome.Kontrolles = db.Kontrolles;
            viewModelHome.Aufgabes = db.Aufgabes;
            //ViewBags für Risikobewertung
            var riskcount6 = viewModelHome.Risikos.Where(r => r.Bewertung < 6).Count();
            ViewBag.Risk6 = riskcount6;
            var riskcount6bis8 = viewModelHome.Risikos.Where(r => r.Bewertung > 5 && r.Bewertung <9).Count();
            ViewBag.Risk6bis8 = riskcount6bis8;
            var riskcount9bis10 = viewModelHome.Risikos.Where(r => r.Bewertung > 8).Count();
            ViewBag.Risk9bis10 = riskcount9bis10;

            return View(viewModelHome);
        }



    }
}