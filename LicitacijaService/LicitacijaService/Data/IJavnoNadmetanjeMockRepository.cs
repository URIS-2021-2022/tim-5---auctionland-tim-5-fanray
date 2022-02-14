using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicitacijaService.Models;

namespace LicitacijaService.Data
{
    public interface IJavnoNadmetanjeMockRepository
    {
        List<SluzbeniListDto> GetSluzbeniListList();
        SluzbeniListDto GetSluzbeniListById(Guid sluzbeniListId);
        List<TipJavnogNadmetanjaDto> GetTipJavnogNadmetanjaList();
        TipJavnogNadmetanjaDto GetTipJavnogNadmetanjaById(Guid tipJavnogNadmetanjaId);
        List<StatusJavnogNadmetanjaDto> GetStatusJavnogNadmetanjaList();
        StatusJavnogNadmetanjaDto GetStatusJavnogNadmetanjaById(Guid statusJavnogNadmetanjaId);
        List<KatastarskaOpstinaDto> GetKatastarskaOpstinaList();
        KatastarskaOpstinaDto GetKatastarskaOpstinaById(Guid katastarskaOpstinaId);
    }
}
