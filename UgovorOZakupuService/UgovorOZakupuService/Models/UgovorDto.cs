using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuService.Models
{
    public class UgovorDto
    {

        public Guid UgovorID { get; set; }
        public Guid KorisnikID { get; set; }
        public Guid KupacID { get; set; }
        public Guid JavnoNadmetanjeID { get; set; }
        public Guid LicnostID { get; set; }
        public RokDto Rok { get; set; }
        public DokumentDto Dokument { get; set; }
        public TipGarancijeDto TipGarancije { get; set; }
        public string ZavodniBroj { get; set; }
        public string MestoPotpisivanja { get; set; }
        public DateTime DatumZavodjenja { get; set; }
        public DateTime RokZaVracanjeZem { get; set; }
        public DateTime DatumPotpisa { get; set; }

    }
}
