using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicnostService.Entities
{
    public class Clan
    {
        [Key]
        public Guid ClanID { get; set; }

        [ForeignKey("Licnost")]
        public Guid LicnostID { get; set; }
        public Licnost Licnost { get; set; }

        
    }
}
