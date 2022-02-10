using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZalbaService.Entities
{
    public class StatusZalbe
    {
        [Key]
        public Guid StatusZalbeID { get; set; }

        [Required]
        public string NazivStatusaZalbe { get; set; }

        //public List<Zalba> ZalbaList { get; set; }
    }
}