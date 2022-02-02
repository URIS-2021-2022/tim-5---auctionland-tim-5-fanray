using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicitacijaService.Entities;

namespace LicitacijaService.Data
{
    public interface IDokumentacijaZaPravnoLiceRepository
    {
        List<DokumentacijaZaPravnoLice> GetDokumentacijaZaPravnoLiceList();
        DokumentacijaZaPravnoLice GetDokumentacijaZaPravnoLiceById(Guid dokumentacijaPlId);
    }
}
