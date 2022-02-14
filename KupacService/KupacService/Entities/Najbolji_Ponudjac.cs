using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacService.Entities
{
    public class Najbolji_Ponudjac
    {
        public Guid NajboljiPonudjacId { get; set; }
        public Guid? KupacId { get; set; }
    }
}
