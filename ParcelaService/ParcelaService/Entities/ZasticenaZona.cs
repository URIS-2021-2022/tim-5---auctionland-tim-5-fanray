using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParcelaService.Entities
{
    public class ZasticenaZona
    {
        [Key]
        public Guid ZasticenaZonaID { get; set; }

        [Required]
        public string NazivZasticeneZone { get; set; }

        public List<Parcela> ParcelaList { get; set; }
    }
}
