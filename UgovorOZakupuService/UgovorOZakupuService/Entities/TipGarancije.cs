using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuService.Entities
{
    public class TipGarancije
    {
        [Key]
        public Guid TipGarancijeID { get; set;  }

        [Required]
        public string NazivTipaG { get; set; }
    }
}
