using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZalbaService.Entities
{
    public class Zalba
    {
        [Key]
        public Guid ZalbaID { get; set; }

        public DateTime Datum_Podnosenja_Zalbe { get; set; }
        public string Razlog_Podnosenja_Zalbe { get; set; }
        public string Obrazlozenje { get; set; }
        public DateTime Datum_Resenja { get; set; }
        public int Broj_Resenja { get; set; }
        public int Broj_Nadmetanja { get; set; }


        [ForeignKey("RadnjaNaOsnovuZalbe")]
        public Guid? RadnjaNaOsnovuZalbeID { get; set; }
        public RadnjaNaOsnovuZalbe RadnjaNaOsnovuZalbe { get; set; }

        [ForeignKey("StatusZalbe")]
        public Guid? StatusZalbeID { get; set; }
        public StatusZalbe StatusZalbe { get; set; }

        [ForeignKey("TipZalbe")]
        public Guid? TipZalbeID { get; set; }
        public TipZalbe TipZalbe { get; set; }

    }
}