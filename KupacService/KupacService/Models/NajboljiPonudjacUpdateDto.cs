using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacService.Models
{
    public class NajboljiPonudjacUpdateDto
    {
        public Guid NajboljiPonudjacId { get; set; }
        public Guid? KupacId { get; set; }
    }
}
