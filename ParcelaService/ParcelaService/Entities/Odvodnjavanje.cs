using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParcelaService.Entities
{
    public class Odvodnjavanje
    {
        [Key]
        public Guid OdvodnjavanjeID { get; set; }

        [Required]
        public string NazivOdvodnjavanja { get; set; }

        public List<Parcela> ParcelaList { get; set; }
    }
}
