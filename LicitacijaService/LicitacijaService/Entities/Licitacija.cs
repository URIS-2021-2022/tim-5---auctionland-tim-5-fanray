using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicitacijaService.Entities
{
    public class Licitacija
    {
        [Key]
        public Guid LicitacijaID { get; set; }

        [ForeignKey("Dokumentacija")]
        public Guid? DokumentacijaID  { get; set; }
        public Dokumentacija Dokumentacija { get; set; }

        public int Broj { get; set; }

        public int Godina { get; set; }

        public DateTime Datum { get; set; }

        public string Ogranicenje { get; set; }

        public string KorakCene { get; set; }

        public DateTime RokZaPrijavu { get; set; }
    }
}
