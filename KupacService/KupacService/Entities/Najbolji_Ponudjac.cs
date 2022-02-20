using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KupacService.Entities
{
    public class Najbolji_Ponudjac
    {
        [Key]
        public Guid NajboljiPonudjacId { get; set; }
        public Guid? KupacId { get; set; }
    }
}
