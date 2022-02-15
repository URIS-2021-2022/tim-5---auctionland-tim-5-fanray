using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceService.Entities
{
    public class FizickoLice
    {
        public Guid LiceID { get; set; }
        public Guid JMBG { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }


    }
}
