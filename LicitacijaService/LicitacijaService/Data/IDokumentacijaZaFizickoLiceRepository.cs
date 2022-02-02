using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicitacijaService.Entities;

namespace LicitacijaService.Data
{
    public interface IDokumentacijaZaFizickoLiceRepository
    {
        List<DokumentacijaZaFizickoLice> GetDokumentacijaZaFizickoLiceList();
        DokumentacijaZaFizickoLice GetDokumentacijaZaPravnoLiceById(Guid dokumentacijaFlId);
    }
}
