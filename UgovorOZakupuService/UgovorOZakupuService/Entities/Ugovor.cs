using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuService.Entities
{
    public class Ugovor
    {
        [Key]
        public Guid UgovorID { get; set; }
        public Guid KorisnikID { get; set; }
        public string ZavodniBroj { get; set; }
        public DateTime DatumZavodjenja { get; set; }
        public DateTime RokZaVracanjeZem { get; set; }
        public string MestoPotpisivanja { get; set; }
        public DateTime DatumPotpisa { get; set; }
        public Guid JavnoNadmetanjeID { get; set; }
        public Guid KupacID { get; set; }
        public Guid LicnostID { get; set; }

        [ForeignKey("Dokument")]
        public Guid DokumentID { get; set; }
        public Dokument Dokument { get; set; }
        [ForeignKey("TipGarancije")]
        public Guid TipGarancijeID { get; set; }
        public TipGarancije TipGarancije { get; set; }
        [ForeignKey("Rok")]
        public Guid RokID { get; set; }
        public Rok Rok { get; set; }
    }
}
