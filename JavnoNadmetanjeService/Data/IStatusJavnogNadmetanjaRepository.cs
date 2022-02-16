using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JavnoNadmetanjeService.Entities;
using JavnoNadmetanjeService.Models;

namespace JavnoNadmetanjeService.Data
{
    public interface IStatusJavnogNadmetanjaRepository
    {
        List<StatusJavnogNadmetanja> GetStatusJavnogNadmetanjaList();
        StatusJavnogNadmetanja GetStatusJavnogNadmetanjaById(Guid statusJavnogNadmetanjaId);
        StatusJavnogNadmetanjaConfirmationDto CreateStatusJavnogNadmetanja(StatusJavnogNadmetanja statusJavnogNadmetanja);
        StatusJavnogNadmetanjaConfirmationDto UpdateStatusJavnogNadmetanja(StatusJavnogNadmetanja statusJavnogNadmetanja);
        StatusJavnogNadmetanjaConfirmationDto DeleteStatusJavnogNadmetanja(Guid statusJavnogNadmetanjaId);
    }
}
