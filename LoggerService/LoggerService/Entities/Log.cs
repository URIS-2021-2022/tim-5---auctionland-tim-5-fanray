using System;
using System.ComponentModel.DataAnnotations;

namespace LoggerService.Entities
{
    public class Log
    {
        [Key]
        public Guid LogID { get; set; }

        [Required]
        public string Opis { get; set; }

        [Required]
        public string DatumKreiranja { get; set; }
        
        [Required]
        public string VremeKreiranja { get; set; }
    }
}
