using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OvlascenoLiceService.Entities;
using OvlascenoLiceService.Models;

namespace OvlascenoLiceService.Data
{
    public interface IAdresaMockRepository
    {
        List<AdresaDto> GetAdresaList();
        AdresaDto GetAdresaById(Guid adresaId);
    }
}