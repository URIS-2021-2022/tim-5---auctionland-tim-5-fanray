using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanjeService.Models
{
    public class TipJavnogNadmetanjaUpdateDto
    {
        public Guid TipJavnogNadmetanjaId { get; set; }

        public string NazivTipaJavnogNadmetanja { get; set; }
    }
}
