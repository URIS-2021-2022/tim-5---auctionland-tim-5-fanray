using System;

namespace ParcelaService.Models
{
    public class DeoParceleDto
    {
        public Guid DeoParceleID { get; set; }
        public ParcelaDto Parcela { get; set; }
        public string NazivDelaParcele { get; set; }
    }
}
