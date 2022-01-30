using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParcelaService.Entities
{
    public class Kultura
    {
        [Key]
        public Guid KulturaID { get; set; }

        [Required]
        public string NazivKulture { get; set; }

        public List<Parcela> ParcelaList { get; set; }
    }
}
