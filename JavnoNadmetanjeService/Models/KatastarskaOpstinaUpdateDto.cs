using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanjeService.Models
{
    public class KatastarskaOpstinaUpdateDto
    {
        public Guid KatastarskaOpstinaId { get; set; }

        public string NazivKatastarskeOpstine { get; set; }
    }
}
