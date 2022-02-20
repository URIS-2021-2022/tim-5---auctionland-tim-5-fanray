using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JavnoNadmetanjeService.Entities;
using JavnoNadmetanjeService.Models;

namespace JavnoNadmetanjeService.Data
{
    public interface ITipJavnogNadmetanjaRepository
    {
        List<TipJavnogNadmetanja> GetTipJavnogNadmetanjaList();
        TipJavnogNadmetanja GetTipJavnogNadmetanjaById(Guid tipJavnogNadmetanjaId);
        TipJavnogNadmetanjaConfirmationDto CreateTipJavnogNadmetanja(TipJavnogNadmetanja tipJavnogNadmetanja);
        TipJavnogNadmetanjaConfirmationDto UpdateTipJavnogNadmetanja(TipJavnogNadmetanja tipJavnogNadmetanja);
        TipJavnogNadmetanjaConfirmationDto DeleteTipJavnogNadmetanja(Guid tipJavnogNadmetanjaId);
    }
}
