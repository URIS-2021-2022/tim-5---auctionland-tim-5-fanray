using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParcelaService.Entities
{
    public class Klasa
    {
        [Key]
        public Guid KlasaID { get; set; }

        [Required]
        public string NazivKlase { get; set; }

        public List<Parcela> ParcelaList { get; set; }
    }
}
