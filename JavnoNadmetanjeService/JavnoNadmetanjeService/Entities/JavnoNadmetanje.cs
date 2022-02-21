using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanjeService.Entities
{
    public class JavnoNadmetanje
    {
        [Key]
        public Guid JavnoNadmetanjeId { get; set; }

        [ForeignKey("TipJavnogNadmetanja")]
        public Guid TipJavnogNadmetanjaId { get; set; }
        public TipJavnogNadmetanja TipJavnogNadmetanja { get; set; }

        [ForeignKey("StatusJavnogNadmetanja")]
        public Guid StatusJavnogNadmetanjaId { get; set; }
        public StatusJavnogNadmetanja StatusJavnogNadmetanja { get; set; }

        public Guid KatastarskaOpstinaId { get; set; }

        public DateTime Datum { get; set; }

        public DateTime VremePocetka { get; set; }

        public DateTime VremeKraja { get; set; }

        public int PocetnaCenaHektar { get; set; }

        public bool Izuzeto { get; set; }

        public int IzlicitiranaCena { get; set; }

        public int PeriodZakupa { get; set; }

        public int BrojUcesnika { get; set; }

        public int VisinaDopuneDepozita { get; set; }

        public int Krug { get; set; }

        public List<SluzbeniList> SluzbeniListList { get; set; }
    }
}
