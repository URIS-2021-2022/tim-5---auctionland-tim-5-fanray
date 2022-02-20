using System;
using System.ComponentModel.DataAnnotations;

namespace LicitacijaService.Entities
{
    public class DokumentacijaZaPravnoLice
    {
        [Key]
        public Guid DokumentacijaPlID { get; set; }
        public Guid? DokumentacijaID { get; set; }
    }
}
