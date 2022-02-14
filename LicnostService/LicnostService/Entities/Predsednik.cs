using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicnostService.Entities
{
    public class Predsednik
    {
        [Key]
        public Guid PredsednikID { get; set; }

        [ForeignKey("Licnost")]
        public Guid LicnostID { get; set; }
        public Licnost Licnost { get; set; }

       
    }
}
