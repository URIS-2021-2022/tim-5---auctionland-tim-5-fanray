using System;

namespace OvlascenoLiceService.Models
{
    public class OvlascenoLiceCreateDto
    {

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string JMBG { get; set; }

        public string BrojPasosa { get; set; }

        public Guid BrojTableID { get; set; }

        public Guid DrzavaID { get; set; }
    }
}