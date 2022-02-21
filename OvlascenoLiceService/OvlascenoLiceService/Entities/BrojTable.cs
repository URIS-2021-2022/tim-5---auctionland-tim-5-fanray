using System;
using System.Collections.Generic;

namespace OvlascenoLiceService.Entities
{
    public class BrojTable
    {
        public Guid BrojTableID { get; set; }
        public string Broj_Table { get; set; }
        public List<OvlascenoLice> OvlascenoLiceList { get; set; }
    }
}