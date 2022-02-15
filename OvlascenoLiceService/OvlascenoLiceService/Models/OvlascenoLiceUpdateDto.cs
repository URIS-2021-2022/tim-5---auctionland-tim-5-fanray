using System;

namespace OvlascenoLiceService.Models
{
    public class OvlascenoLiceUpdateDto
    {
        public Guid OvlascenoLiceID { get; set; }
        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string JMBG { get; set; }

        public string BrojPasosa { get; set; }

        public Guid BrojTableID { get; set; }

        public Guid DrzavaID { get; set; }
    }
}