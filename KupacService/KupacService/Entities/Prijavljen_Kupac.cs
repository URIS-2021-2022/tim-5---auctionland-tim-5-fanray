using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacService.Entities
{
    public class Prijavljen_Kupac
    {
        public Guid PrijavljenKupacId { get; set; }
        public Guid? KupacId { get; set; }
    }
}
