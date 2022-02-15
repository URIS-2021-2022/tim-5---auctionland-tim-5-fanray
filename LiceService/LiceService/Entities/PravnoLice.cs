using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceService.Entities
{
    public class PravnoLice
    {

        public Guid LiceID { get; set; }
        public Guid Maticni_broj { get; set; }
        public string Naziv { get; set; }


    }
}
