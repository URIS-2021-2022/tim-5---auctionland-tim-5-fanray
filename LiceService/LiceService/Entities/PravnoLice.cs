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
       public Guid LiceID { get; set; }
       public string Naziv { get; set; }
       public Guid? MaticniBroj { get; set; }
    }
}
