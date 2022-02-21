using System;
using System.Collections.Generic;

namespace AdresaService.Entities
{
    public class Drzava
    {
        public Guid DrzavaID { get; set; }
        public string NazivDrzave { get; set; }
        public List<Adresa> AdresaList { get; set; }
    }
}
