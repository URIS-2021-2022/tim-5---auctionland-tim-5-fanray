using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuService.Models
{
    public class DokumentDto
    {
        public Guid DokumentID { get; set; }
        public string ZavodniBrojD { get; set; }
        public DateTime Datum { get; set; }
        public DateTime DatumDonosenja { get; set; }
        public string Sablon { get; set; }
    }
}
