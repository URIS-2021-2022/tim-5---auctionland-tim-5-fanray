using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicnostService.Entities
{
    public class Komisija
    {
        [Key]
        public Guid KomisijaID { get; set; }

        [ForeignKey("Clan")]
        public Guid? ClanID { get; set; }
        public Clan Clan { get; set; }

        [ForeignKey("Predsednik")]
        public Guid? PedsednikID { get; set; }
        public Predsednik Predsednik { get; set; }
    }
}
