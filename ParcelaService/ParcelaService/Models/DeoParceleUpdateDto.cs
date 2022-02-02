using System;

namespace ParcelaService.Models
{
    public class DeoParceleUpdateDto
    {
        public Guid DeoParceleID { get; set; }
        public Guid ParcelaID { get; set; }
        public string NazivDelaParcele { get; set; }
    }
}
