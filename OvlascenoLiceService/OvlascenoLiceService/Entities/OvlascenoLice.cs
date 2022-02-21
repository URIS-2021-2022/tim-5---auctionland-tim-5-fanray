using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey("BrojTable")]
        public Guid BrojTableID { get; set; }
        public BrojTable BrojTable { get; set; }
        public Guid DrzavaID { get; set; }
    }
}