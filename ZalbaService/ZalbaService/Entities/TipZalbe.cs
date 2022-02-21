using System;
using System.Collections.Generic;

namespace ZalbaService.Entities
{
    public class TipZalbe
    {
        public Guid TipZalbeID { get; set; }
        public string NazivTipaZalbe { get; set; }
        public List<Zalba> ZalbaList { get; set; }
    }
}