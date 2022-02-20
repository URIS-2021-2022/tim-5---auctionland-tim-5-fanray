using System;
using System.ComponentModel.DataAnnotations;

namespace LicitacijaService.Entities
{
    public class DokumentacijaZaFizickoLice
    {
        [Key]
        public Guid DokumentacijaFlID { get; set; }
        public Guid? DokumentacijaID { get; set; }
    }
}
