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
        ParcelaConfirmationDto CreateParcela(ParcelaCreateDto parcelaDto);
        ParcelaConfirmationDto UpdateParcela(ParcelaUpdateDto parcelaDto);
        ParcelaConfirmationDto DeleteParcela(Guid parcelaId);
    }
}
