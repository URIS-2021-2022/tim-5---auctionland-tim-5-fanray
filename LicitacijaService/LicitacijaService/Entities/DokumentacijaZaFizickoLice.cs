using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicitacijaService.Entities
{
    public class DokumentacijaZaFizickoLice
    {
        [Key]
        public Guid DokumentacijaFlID { get; set; }
        [ForeignKey("Dokumentacija")]
        public Guid? DokumentacijaID { get; set; }
        public Dokumentacija Dokumentacija { get; set; }
    }
}
