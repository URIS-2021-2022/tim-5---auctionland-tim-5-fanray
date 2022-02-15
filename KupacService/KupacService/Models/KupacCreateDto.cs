using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacService.Models
{
    public class KupacCreateDto
    {
        public Guid? PrioritetId { get; set; }
        public string OstvarenaPovrsina { get; set; }
        public Guid? OvlascenoLiceId { get; set; }
        public bool ImaZabranu { get; set; }
        public DateTime DatumPocetkaZabrane { get; set; }
        public string DatumTrajanjaZabrane { get; set; }
        public DateTime DatumPrestankaZabrane { get; set; }
 
    }
}
