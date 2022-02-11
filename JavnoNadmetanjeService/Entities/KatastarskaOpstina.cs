using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanjeService.Entities
{
    public class KatastarskaOpstina
    {
        [Key]
        public Guid KatastarskaOpstinaId { get; set; }

        [Required]
        public string NazivKatastarskeOpstine { get; set; }

        public List<JavnoNadmetanje> JavnoNadmetanjeList { get; set; }
    }
}
