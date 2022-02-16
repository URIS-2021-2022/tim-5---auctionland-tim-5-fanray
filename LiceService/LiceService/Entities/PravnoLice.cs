using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LiceService.Entities
{
    public class PravnoLice
    {

       [Key]
        public Guid Maticni_broj { get; set; }
        public string Naziv { get; set; }

        [ForeignKey("Lice")]
        public Guid? LiceID { get; set; }
        public Lice Lice { get; set; }



    }
}
