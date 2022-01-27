using ParcelaService.Entities;
using ParcelaService.Models;
using System;
using System.Collections.Generic;

namespace ParcelaService.Data
{
    public interface IParcelaRepository
    {
        List<Parcela> GetParcelaList();
        Parcela GetParcelaById(Guid parcelaId);
        ParcelaConfirmationDto CreateParcela(Parcela parcela);
        ParcelaConfirmationDto UpdateParcela(Parcela parcela);
        ParcelaConfirmationDto DeleteParcela(Guid parcelaId);
    }
}
