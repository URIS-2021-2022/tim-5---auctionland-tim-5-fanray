using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanjeService.Entities
{
    public class StatusJavnogNadmetanja
    {
        public Guid StatusJavnogNadmetanjaId { get; set; }
        public string NazivStatusaJavnogNadmetanja { get; set; }

        public List<JavnoNadmetanje> JavnoNadmetanjeList { get; set; }
    }
}
