using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicitacijaService.Entities;

namespace LicitacijaService.Data
{
    public interface IDokumentacijaRepository
    {
        List<Dokumentacija> GetDokumentacijaList();
        Dokumentacija GetDokumentacijaById(Guid dokumentacijaId);
    }
}
