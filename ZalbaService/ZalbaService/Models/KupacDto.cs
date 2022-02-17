using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZalbaService.Models
{
    public class KupacDto
    {
        public Guid KupacID { get; set; }
        public Guid PrioritetID { get; set; }
        public string OstvarenaPovrsina { get; set; }
        public Guid UplataID { get; set; }
        public Guid OvlascenoLiceID { get; set; }
        public bool ImaZabranu { get; set; }
        public DateTime DatumPocetkaZabrane { get; set; }
        public string DatumTrajanjaZabrane { get; set; }
        public DateTime DatumPrestankaZabrane { get; set; }
        public Guid JavnoNadmetanjeID { get; set; }
    }
}
