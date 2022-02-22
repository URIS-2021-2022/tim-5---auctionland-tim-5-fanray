using System;

namespace LoggerService.Models
{
    public class LogDto
    {
        public Guid LogID { get; set; }
        public string Mikroservis { get; set; }
        public string Entitet { get; set; }
        public string Zahtjev { get; set; }
        public int Status { get; set; }
        public string DatumKreiranja { get; set; }
        public string VremeKreiranja { get; set; }
    }
}
