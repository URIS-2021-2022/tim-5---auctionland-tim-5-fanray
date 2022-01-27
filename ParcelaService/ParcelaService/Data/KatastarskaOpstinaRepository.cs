using ParcelaService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParcelaService.Data
{
    public class KatastarskaOpstinaRepository : IKatastarskaOpstinaRepository
    {
        private readonly ParcelaContext Context;

        public KatastarskaOpstinaRepository(ParcelaContext context)
        {
            this.Context = context;
        }

        public List<KatastarskaOpstina> GetKatastarskaOpstinaList()
        {
            return Context.KatastarskaOpstina.ToList();
        }

        public KatastarskaOpstina GetKatastarskaOpstinaById(Guid katastarskaOpstinaId)
        {
            return Context.KatastarskaOpstina.FirstOrDefault(e => e.KatastarskaOpstinaID == katastarskaOpstinaId);
        }
    }
}
