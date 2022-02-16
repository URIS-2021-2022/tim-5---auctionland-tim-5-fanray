using JavnoNadmetanjeService.Entities;
using JavnoNadmetanjeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanjeService.Data
{
    public interface IKatastarskaOpstinaRepository
    {
        List<KatastarskaOpstina> GetKatastarskaOpstinaList();
        KatastarskaOpstina GetKatastarskaOpstinaById(Guid katastarskaOpstinaId);
        KatastarskaOpstinaConfirmationDto CreateKatastarskaOpstina(KatastarskaOpstina katastarskaOpstina);
        KatastarskaOpstinaConfirmationDto DeleteKatastarskaOpstina(Guid katastarskaOpstinaId);
        KatastarskaOpstinaConfirmationDto UpdateKatastarskaOpstina(KatastarskaOpstina katastarskaOpstina);


    }
}
