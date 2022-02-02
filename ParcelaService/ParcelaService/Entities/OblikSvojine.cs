using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParcelaService.Entities
{
    public class OblikSvojine
    {
        [Key]
        public Guid OblikSvojineID { get; set; }

        [Required]
        public string NazivOblikaSvojine { get; set; }

        public List<Parcela> ParcelaList { get; set; }
    }
}
