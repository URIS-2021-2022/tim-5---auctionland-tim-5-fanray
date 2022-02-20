using System;
using System.ComponentModel.DataAnnotations;

namespace OvlascenoLiceService.Entities
{
    public class OvlascenoLice
    {
        [Key]
        public Guid OvlascenoLiceID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string JMBG { get; set; }
        public string BrojPasosa { get; set; }
        public Guid? BrojTableID { get; set; }
        public Guid? DrzavaID { get; set; }
    }
}