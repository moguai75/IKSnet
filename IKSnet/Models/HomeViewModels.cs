using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IKSnet.Models
{
    public class HomeIndexData
    {
        public IEnumerable<Risiko> Risikos { get; set; }
        public IEnumerable<Risikokategorie> Risikokategories { get; set; }
        public IEnumerable<Kontrolle> Kontrolles { get; set; }
        public IEnumerable<Aufgabe> Aufgabes { get; set; }

    }

}