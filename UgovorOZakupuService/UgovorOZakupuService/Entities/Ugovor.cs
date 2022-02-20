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
        public Guid UgovorID { get; set; }
        public Guid KorisnikID { get; set; }
        public string ZavodniBroj { get; set; }
        public DateTime DatumZavodjenja { get; set; }
        public DateTime RokZaVracanjeZem { get; set; }
        public string MestoPotpisivanja { get; set; }
        public DateTime DatumPotpisa { get; set; }
       public Guid? JavnoNadmetanjeID { get; set; }
       public Guid? KupacID { get; set; }
       public Guid? LicnostID { get; set; }
       public Guid? DokumentID { get; set; }
       public Guid? TipGarancijeID { get; set; }
       public Guid? RokID { get; set; }
    }
}
