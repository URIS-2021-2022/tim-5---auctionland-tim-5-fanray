using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZalbaService.Models
{
    public class ZalbaCreateDto
    {
        public DateTime Datum_Podnosenja_Zalbe { get; set; }

        public string Razlog_Podnosenja_Zalbe { get; set; }

        public string Obrazlozenje { get; set; }

        public DateTime Datum_Resenja { get; set; }

        public int Broj_Resenja { get; set; }

        public int Broj_Nadmetanja { get; set; }

        public Guid RadnjaNaOsnovuZalbeID { get; set; }

        public Guid StatusZalbeID { get; set; }

        public Guid TipZalbeID { get; set; }
    }
}