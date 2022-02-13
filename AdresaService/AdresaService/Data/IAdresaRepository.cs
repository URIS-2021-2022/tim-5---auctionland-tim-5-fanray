using AdresaService.Entities;
using AdresaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaService.Data
{
    public interface IAdresaRepository
    {
        List<Adresa> GetAdresaList();
        Adresa GetAdresaById(Guid adresaId);
        AdresaConfirmationDto CreateAdresa(Adresa adresa);
        AdresaConfirmationDto UpdateAdresa(Adresa adresa);
        AdresaConfirmationDto DeleteAdresa(Guid adresaId);
    }
}
