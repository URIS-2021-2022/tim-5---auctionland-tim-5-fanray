using LicitacijaService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicitacijaService.Data
{
    public class DokumentacijaZaFizickoLiceRepository : IDokumentacijaZaFizickoLiceRepository
    {
        private readonly LicitacijaContext Context;

        public DokumentacijaZaFizickoLiceRepository(LicitacijaContext context)
        {
            this.Context = context;
        }


        public List<DokumentacijaZaFizickoLice> GetDokumentacijaZaFizickoLiceList()
        {
            return Context.DokumentacijaZaFizickoLice.ToList();
        }

        public DokumentacijaZaFizickoLice GetDokumentacijaZaFizickoLiceById(Guid dokumentacijaFlId)
        {
            return Context.DokumentacijaZaFizickoLice.FirstOrDefault(e => e.DokumentacijaFlID == dokumentacijaFlId);
        }
    }
}
