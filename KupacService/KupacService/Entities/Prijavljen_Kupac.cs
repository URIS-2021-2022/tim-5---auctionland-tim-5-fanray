using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KupacService.Entities
{
    public class Prijavljen_Kupac
    {
        [Key]
        public Guid PrijavljenKupacId { get; set; }
        public Guid? KupacId { get; set; }
    }
}
