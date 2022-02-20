using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LiceService.Entities
{
    public class FizickoLice
    {
        [Key]
        public Guid LiceID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public Guid? JMBG { get; set; }
    }
}
