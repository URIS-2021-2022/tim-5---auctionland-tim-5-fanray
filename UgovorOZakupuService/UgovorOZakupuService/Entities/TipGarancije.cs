using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuService.Entities
{
    public class TipGarancije
    {
        public Guid TipGarancijeID { get; set;  }
        public string NazivTipaG { get; set; }
        public List<Ugovor> UgovorList { get; set; }
    }
}
