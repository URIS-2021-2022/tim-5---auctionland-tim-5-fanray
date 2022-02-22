using System;
using System.ComponentModel.DataAnnotations;

namespace LoggerService.Entities
{
    public class Log
    {
        [Key]
        public Guid LogID { get; set; }

        [Required]
        public string Mikroservis { get; set; }

        [Required]
        public string Entitet { get; set; }

        [Required]
        public string Zahtjev { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public string DatumKreiranja { get; set; }
        
        [Required]
        public string VremeKreiranja { get; set; }
    }
}
