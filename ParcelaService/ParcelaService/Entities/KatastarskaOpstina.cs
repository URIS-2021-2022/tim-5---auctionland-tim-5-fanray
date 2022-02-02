using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParcelaService.Entities
{
    public class KatastarskaOpstina
    {
        [Key]
        public Guid KatastarskaOpstinaID { get; set; }

        [Required]
        public string NazivKatastarskeOpstine { get; set; }

        public List<Parcela> ParcelaList { get; set; }
    }
}
