using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OvlascenoLiceService.Entities
{
    public class Drzava
    {
        [Key]
        public Guid DrzavaID { get; set; }

        [Required]
        public string NazivDrzave { get; set; }

        public List<OvlascenoLice> OvlascenoLiceList { get; set; }
    }
}