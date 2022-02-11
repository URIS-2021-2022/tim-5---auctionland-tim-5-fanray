using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZalbaService.Entities
{
    public class RadnjaNaOsnovuZalbe
    {
        [Key]
        public Guid RadnjaNaOsnovuZalbeID { get; set; }

        [Required]
        public string NazivRadnjeNaOsnovuZalbe { get; set; }

        public List<Zalba> ZalbaList { get; set; }
    }
}