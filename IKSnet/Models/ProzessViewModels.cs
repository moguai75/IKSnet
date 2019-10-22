using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IKSnet.Models
{
    public class ProzessIndexData
    {
        public IEnumerable<Prozess> Prozesss { get; set; }
        public IEnumerable<Prozessaktivitaet> Prozessaktivitaets { get; set; }
        
    }

}