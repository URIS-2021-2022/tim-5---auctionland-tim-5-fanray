using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicitacijaService.Models
{
    public class SluzbeniListDto
    {
        public Guid JavnoNadmetanjeId { get; set; }
        public Guid SluzbeniListId { get; set; }
        public string Opstina { get; set; }
        public int BrojSluzbenogLista { get; set; }
        public DateTime DatumIzdavanja { get; set; }
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
