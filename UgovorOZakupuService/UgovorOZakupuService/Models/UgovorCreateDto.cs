using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuService.Models
{
    public class UgovorCreateDto
    {
        public Guid KorisnikID { get; set; }
        public Guid KupacID { get; set; }
        public Guid JavnoNadmetanjeID { get; set; }
        public Guid LicnostID { get; set; }
        public Guid RokID { get; set; }
        public Guid DokumentID { get; set; }
        public Guid TipGarancijeID { get; set; }
        public string ZavodniBroj { get; set; }
        public string MestoPotpisivanja { get; set; }
        public DateTime DatumZavodjenja { get; set; }
        public DateTime RokZaVracanjeZem { get; set; }
        public DateTime DatumPotpisa { get; set; }
    }
}
