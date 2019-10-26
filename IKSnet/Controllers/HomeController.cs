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
            var viewModel = new HomeIndexData();
            viewModel.Risikos = db.Risikos
                .Include(i => i.Kontrolles.Select(c => c.Aufgabes)).ToList();
            return View(viewModel);
        }



    }
}