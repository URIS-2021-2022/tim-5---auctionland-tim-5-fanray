using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZalbaService.Entities
{
    public class TipZalbe
    {
        [Key]
        public Guid TipZalbeID { get; set; }

        [Required]
        public string NazivTipaZalbe { get; set; }

        //public List<Zalba> ZalbaList { get; set; }
    }
}