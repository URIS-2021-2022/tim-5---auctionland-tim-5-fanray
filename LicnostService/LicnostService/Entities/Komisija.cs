using System;

namespace LicnostService.Entities
{
    public class Komisija
    {
        public Guid KomisijaID { get; set; }
        public Guid? ClanID { get; set; }
        public Guid? PredsednikID { get; set; }
    }
}
