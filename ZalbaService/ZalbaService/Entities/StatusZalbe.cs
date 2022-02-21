using System;
using System.Collections.Generic;

namespace ZalbaService.Entities
{
    public class StatusZalbe
    {
        public Guid StatusZalbeID { get; set; }
        public string NazivStatusaZalbe { get; set; }
        public List<Zalba> ZalbaList { get; set; }
    }
}