using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicitacijaService.Entities;
using LicitacijaService.Models;

namespace LicitacijaService.Data
{
    public interface ILicitacijaRepository
    {
        List<Licitacija> getLicitacijaList();

        Licitacija getLicitacijaById(Guid licitacijaID);

       LicitacijaConfirmationDto CreateLicitacija(Licitacija licitacija);

        LicitacijaConfirmationDto UpdateLicitacija(Licitacija licitacija);

        LicitacijaConfirmationDto DeleteLicitacija(Guid licitacijaId);
    }
}
