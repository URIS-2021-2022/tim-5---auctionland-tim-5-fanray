using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OvlascenoLiceService.Entities
{
    public class BrojTable
    {
        [Key]
        public Guid BrojTableID { get; set; }

        [Required]
        public string Broj_Table { get; set; }

        public List<OvlascenoLice> OvlascenoLiceList { get; set; }
    }
}