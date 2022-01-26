using ParcelaService.Entities;
using System;
using System.Collections.Generic;

namespace ParcelaService.Data
{
    public interface IKatastarskaOpstinaRepository
    {
        List<KatastarskaOpstina> GetKatastarskaOpstinaList();
        KatastarskaOpstina GetKatastarskaOpstinaById(Guid katastarskaOpstinaId);
    }
}
