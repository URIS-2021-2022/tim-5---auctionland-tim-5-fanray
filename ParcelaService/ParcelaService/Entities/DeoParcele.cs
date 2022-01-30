using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelaService.Entities
{
    public class DeoParcele
    {
        [Key]
        public Guid DeoParceleID { get; set; }

        [Required]
        public string NazivDelaParcele { get; set; }

        [ForeignKey("Parcela")]
        public Guid ParcelaID { get; set; }
        public Parcela Parcela { get; set; }
    }
}
