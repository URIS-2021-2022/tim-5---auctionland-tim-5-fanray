using LicitacijaService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicitacijaService.Data
{
    public class DokumentacijaRepository : IDokumentacijaRepository
    {
        private readonly LicitacijaContext Context;

        public DokumentacijaRepository(LicitacijaContext context)
        {
            this.Context = context;
        }

        public Dokumentacija GetDokumentacijaById(Guid dokumentacijaId)
        {
            return Context.Dokumentacija.FirstOrDefault(e => e.DokumentacijaID == dokumentacijaId);
        }

        public List<Dokumentacija> GetDokumentacijaList()
        {
            return Context.Dokumentacija.ToList();
        }
    }
}
