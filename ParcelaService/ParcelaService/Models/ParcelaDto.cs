using System;

namespace ParcelaService.Models
{
    public class ParcelaDto
    {
        public Guid ParcelaID { get; set; }
        public Guid KorisnikParceleID { get; set; }
        public LiceDto KorisnikParcele { get; set; }
        public int Povrsina { get; set; }
        public string BrojParcele { get; set; }
        public KatastarskaOpstinaDto KatastarskaOpstina { get; set; }
        public string BrojListaNepokretnosti { get; set; }
        public KulturaDto Kultura { get; set; }
        public KlasaDto Klasa { get; set; }
        public ObradivostDto Obradivost { get; set; }
        public ZasticenaZonaDto ZasticenaZona { get; set; }
        public OblikSvojineDto OblikSvojine { get; set; }
        public OdvodnjavanjeDto Odvodnjavanje { get; set; }
        public string KulturaStvarnoStanje { get; set; }
        public string KlasaStvarnoStanje { get; set; }
        public string ObradivostStvarnoStanje { get; set; }
        public string ZasticenaZonaStvarnoStanje { get; set; }
        public string OdvodnjavanjeStvarnoStanje { get; set; }
    }
}
