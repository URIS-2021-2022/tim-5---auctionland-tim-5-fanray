using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanjeService.Entities
{
    public class TipJavnogNadmetanja
    {
        [Key]
        public Guid TipJavnogNadmetanjaId { get; set; }

        [Required]
        public string NazivTipaJavnogNadmetanja { get; set; }

        public List<JavnoNadmetanje> JavnoNadmetanjeList { get; set; }
    }
}
