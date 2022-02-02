using LicitacijaService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicitacijaService.Data
{
    public class DokumentacijaZaPravnoLiceRepository : IDokumentacijaZaPravnoLiceRepository
    {
        private readonly LicitacijaContext Context;

        public DokumentacijaZaPravnoLiceRepository(LicitacijaContext context)
        {
            this.Context = context;
        }

        public DokumentacijaZaPravnoLice GetDokumentacijaZaPravnoLiceById(Guid dokumentacijaPlId)
        {
            return Context.DokumentacijaZaPravnoLice.FirstOrDefault(e => e.DokumentacijaPlID == dokumentacijaPlId);
        }

        public List<DokumentacijaZaPravnoLice> GetDokumentacijaZaPravnoLiceList()
        {
            return Context.DokumentacijaZaPravnoLice.ToList();
        }
    }
}
