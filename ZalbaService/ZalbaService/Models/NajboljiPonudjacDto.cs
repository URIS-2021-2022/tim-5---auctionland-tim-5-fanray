using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZalbaService.Models
{
    public class NajboljiPonudjacDto
    {
        public Guid KupacID { get; set; }
        public Guid NajboljiPonudjacID { get; set; }
        public string OstvarenaPovrsina { get; set; }
        public bool ImaZabranu { get; set; }
        public DateTime DatumPocetkaZabrane { get; set; }
        public string TrajanjaZabraneUGod { get; set; }
        public DateTime DatumPrestankaZabrane { get; set; }
    }
}
