using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanjeService.Entities
{
    public class TipJavnogNadmetanja
    {
        public Guid TipJavnogNadmetanjaId { get; set; }
        public string NazivTipaJavnogNadmetanja { get; set; }
    }
}
