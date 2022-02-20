using System;

namespace LicitacijaService.Entities
{
    public class Licitacija
    {
        public Guid LicitacijaID { get; set; }
        public Guid? DokumentacijaID  { get; set; }
        public int Broj { get; set; }
        public int Godina { get; set; }
        public DateTime Datum { get; set; }
        public string Ogranicenje { get; set; }
        public string KorakCene { get; set; }
        public DateTime RokZaPrijavu { get; set; }
    }
}
