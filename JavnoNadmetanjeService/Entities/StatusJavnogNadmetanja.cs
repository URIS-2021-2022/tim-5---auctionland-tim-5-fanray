using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanjeService.Entities
{
    public class StatusJavnogNadmetanja
    {
        [Key]
        public Guid StatusJavnogNadmetanjaId { get; set; }

        [Required]
        public string NazivStatusaJavnogNadmetanja { get; set; }

        public List<JavnoNadmetanje> JavnoNadmetanjeList { get; set; }
    }
}
