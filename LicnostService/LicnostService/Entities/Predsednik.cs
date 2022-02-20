using System;

namespace LicnostService.Entities
{
    public class Predsednik
    {
        public Guid PredsednikID { get; set; }
        public Guid LicnostID { get; set; }
        public Licnost Licnost { get; set; }
    }
}
