using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanjeService.Models
{
    public class StatusJavnogNadmetanjaUpdateDto
    {
        public Guid StatusJavnogNadmetanjaId { get; set; }

        public string NazivStatusaJavnogNadmetanja { get; set; }
    }
}
