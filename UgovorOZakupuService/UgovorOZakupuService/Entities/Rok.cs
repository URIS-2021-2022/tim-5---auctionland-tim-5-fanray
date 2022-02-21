using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuService.Entities
{
    public class Rok
    {
        public Guid RokID { get; set; }
        public DateTime DatumRokaDospeca { get; set; }
        public List<Ugovor> UgovorList { get; set; }
    }
}
