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

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Index()
        {
            var viewModelHome = new HomeIndexData();
            viewModelHome.Risikokategories = db.Risikokategories;
            viewModelHome.Risikos = db.Risikos;
            viewModelHome.Kontrolles = db.Kontrolles;
            viewModelHome.Aufgabes = db.Aufgabes;
            return View(viewModelHome);
        }



    }
}