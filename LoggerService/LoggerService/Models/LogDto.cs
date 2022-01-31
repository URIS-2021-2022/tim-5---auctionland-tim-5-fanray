using System;

namespace LoggerService.Models
{
    public class LogDto
    {
        public Guid LogID { get; set; }
        public string Opis { get; set; }
        public string DatumKreiranja { get; set; }
        public string VremeKreiranja { get; set; }
    }
}
