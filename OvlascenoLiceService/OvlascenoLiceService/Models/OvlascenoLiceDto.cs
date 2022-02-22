using System;

namespace OvlascenoLiceService.Models
{
    public class OvlascenoLiceDto
    {
        public Guid OvlascenoLiceID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string JMBG { get; set; }
        public string BrojPasosa { get; set; }
        public BrojTableDto BrojTable { get; set; }
        public Guid DrzavaID { get; set; }
        public DrzavaDto Drzava { get; set; }
    }
}