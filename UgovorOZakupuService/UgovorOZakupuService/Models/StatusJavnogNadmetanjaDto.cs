﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuService.Models
{
    public class StatusJavnogNadmetanjaDto
    {
        public Guid JavnoNadmetanjeID { get; set; }
        public Guid StatusJavnogNadmetanjaID { get; set; }
        public string NazivStatusaJavnogNadmetanja { get; set; }
        public AdresaDto Adresa { get; set; }
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

    }
}
