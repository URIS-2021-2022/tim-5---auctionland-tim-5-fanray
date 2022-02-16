using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuService.Models
{
    public class PrioritetDto
    {
        public Guid? KupacID { get; set; }
        public Guid PrioritetID { get; set; }
        public string NazivPrioriteta { get; set; }
        public string OstvarenaPovrsina { get; set; }
        public bool ImaZabranu { get; set; }
        public DateTime DatumPocetkaZabrane { get; set; }
        public string TrajanjaZabraneUGod { get; set; }
        public DateTime DatumPrestankaZabrane { get; set; }
    }
}
