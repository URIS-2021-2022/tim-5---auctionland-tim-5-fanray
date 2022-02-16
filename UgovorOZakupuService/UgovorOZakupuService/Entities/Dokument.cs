using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuService.Entities
{
    public class Dokument
    {
        [Key]
        public Guid DokumentID { get; set; }
        public string ZavodniBrojD { get; set; }
        public DateTime Datum { get; set; }
        public DateTime DatumDonosenja { get; set; }
        public string Sablon { get; set; }

    }
}
