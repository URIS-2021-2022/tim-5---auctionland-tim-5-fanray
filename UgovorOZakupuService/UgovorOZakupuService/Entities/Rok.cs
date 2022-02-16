using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuService.Entities
{
    public class Rok
    {
        [Key]
        public Guid RokID { get; set; }
        public DateTime DatumRokaDospeca { get; set; }
    }
}
