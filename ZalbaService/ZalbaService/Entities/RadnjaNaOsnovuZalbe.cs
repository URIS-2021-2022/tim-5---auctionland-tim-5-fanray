using System;
using System.Collections.Generic;

namespace ZalbaService.Entities
{
    public class RadnjaNaOsnovuZalbe
    {
        public Guid RadnjaNaOsnovuZalbeID { get; set; }
        public string NazivRadnjeNaOsnovuZalbe { get; set; }
        public List<Zalba> ZalbaList { get; set; }
    }
}