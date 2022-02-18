using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KupacService.Entities
{
    public class PrijavljenKupac
    {
        [Key]
        public Guid PrijavljenKupacId { get; set; }
        public Guid? KupacId { get; set; }
    }
}
