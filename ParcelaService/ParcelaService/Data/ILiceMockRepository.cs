using ParcelaService.Models;
using System;
using System.Collections.Generic;

namespace ParcelaService.Data
{
    public interface ILiceMockRepository
    {
        List<FizickoLiceDto> GetFizickoLiceList();
        FizickoLiceDto GetFizickoLiceById(Guid liceId);
        List<PravnoLiceDto> GetPravnoLiceList();
        PravnoLiceDto GetPravnoLiceById(Guid liceId);
    }
}
