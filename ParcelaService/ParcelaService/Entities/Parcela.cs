using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelaService.Entities
{
    public class Parcela
    {
        [Key]
        public Guid ParcelaID { get; set; }

        public Guid? KorisnikParceleID { get; set; }

        public int Povrsina { get; set; }

        public string BrojParcele { get; set; }

        public string BrojListaNepokretnosti { get; set; }

        public string KulturaStvarnoStanje { get; set; }

        public string KlasaStvarnoStanje { get; set; }

        public string ObradivostStvarnoStanje { get; set; }

        public string ZasticenaZonaStvarnoStanje { get; set; }

        public string OdvodnjavanjeStvarnoStanje { get; set; }

        [ForeignKey("KatastarskaOpstina")]
        public Guid? KatastarskaOpstinaID { get; set; }
        public KatastarskaOpstina KatastarskaOpstina { get; set; }

        [ForeignKey("Kultura")]
        public Guid? KulturaID { get; set; }
        public Kultura Kultura { get; set; }

        [ForeignKey("Klasa")]
        public Guid? KlasaID { get; set; }
        public Klasa Klasa { get; set; }

        [ForeignKey("Obradivost")]
        public Guid? ObradivostID { get; set; }
        public Obradivost Obradivost { get; set; }

        [ForeignKey("ZasticenaZona")]
        public Guid? ZasticenaZonaID { get; set; }
        public ZasticenaZona ZasticenaZona { get; set; }

        [ForeignKey("OblikSvojine")]
        public Guid? OblikSvojineID { get; set; }
        public OblikSvojine OblikSvojine { get; set; }

        [ForeignKey("Odvodnjavanje")]
        public Guid? OdvodnjavanjeID { get; set; }
        public Odvodnjavanje Odvodnjavanje { get; set; }

        public List<DeoParcele> DeoParceleList { get; set; }
    }
}
