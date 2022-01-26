using ParcelaService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParcelaService.Data
{
    public class KatastarskaOpstinaRepository : IKatastarskaOpstinaRepository
    {
        private readonly KatastarskaOpstinaContext Context;

        public KatastarskaOpstinaRepository(KatastarskaOpstinaContext context)
        {
            this.Context = context;
        }

        public List<KatastarskaOpstina> GetKatastarskaOpstinaList()
        {
            return Context.KatastarskaOpstinaSet.ToList();
        }

        public KatastarskaOpstina GetKatastarskaOpstinaById(Guid katastarskaOpstinaId)
        {
            return Context.KatastarskaOpstinaSet.FirstOrDefault(e => e.KatastarskaOpstinaID == katastarskaOpstinaId);
        }
    }
}
