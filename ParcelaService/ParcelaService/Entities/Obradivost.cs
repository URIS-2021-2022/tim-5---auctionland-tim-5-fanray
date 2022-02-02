using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParcelaService.Entities
{
    public class Obradivost
    {
        [Key]
        public Guid ObradivostID { get; set; }

        [Required]
        public string NazivObradivosti { get; set; }

        public List<Parcela> ParcelaList { get; set; }
    }
}
