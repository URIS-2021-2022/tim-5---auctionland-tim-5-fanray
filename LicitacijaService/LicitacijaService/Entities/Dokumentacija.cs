using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LicitacijaService.Entities
{
    public class Dokumentacija
    {
        [Key]
        public Guid DokumentacijaID { get; set; }

        [Required]
        public string NazivDokumentacije { get; set; }
    }
}
