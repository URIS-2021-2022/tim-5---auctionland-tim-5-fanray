using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZalbaService.Models
{
    public class ZalbaDto
    {
        public Guid ZalbaID { get; set; }

        public DateTime Datum_Podnosenja_Zalbe { get; set; }

        public string Razlog_Podnosenja_Zalbe { get; set; }

        public string Obrazlozenje { get; set; }

        public DateTime Datum_Resenja { get; set; }

        public int Broj_Resenja { get; set; }

        public int Broj_Nadmetanja { get; set; }

        public RadnjaNaOsnovuZalbeDto RadnjaNaOsnovuZalbe { get; set; }

        public StatusZalbeDto StatusZalbe { get; set; }

        public TipZalbeDto TipZalbe { get; set; }
    }
}