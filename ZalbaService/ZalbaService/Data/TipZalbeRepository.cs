using ZalbaService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZalbaService.Data
{
    public class TipZalbeRepository : ITipZalbeRepository
    {
        private readonly ZalbaContext Context;

        public TipZalbeRepository(ZalbaContext context)
        {
            this.Context = context;
        }

        public TipZalbe GetTipZalbeById(Guid tipZalbeId)
        {
            return Context.TipZalbe.FirstOrDefault(e => e.TipZalbeID == tipZalbeId);
        }

        public List<TipZalbe> GetTipZalbeList()
        {
            return Context.TipZalbe.ToList();
        }
    }
}