using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicitacijaService.Models
{
    public class LicitacijaCreateDto
    {
        public Guid DokumentacijaID { get; set; }

        public int Broj { get; set; }

        public int Godina { get; set; }

        public DateTime Datum { get; set; }

        public string Ogranicenje { get; set; }

        public string KorakCene { get; set; }

        public DateTime RokZaPrijavu { get; set; }
    }
}
