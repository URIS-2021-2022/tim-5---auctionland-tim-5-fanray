using ZalbaService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZalbaService.Data
{
    public class StatusZalbeRepository : IStatusZalbeRepository
    {
        private readonly ZalbaContext Context;

        public StatusZalbeRepository(ZalbaContext context)
        {
            this.Context = context;
        }

        public StatusZalbe GetStatusZalbeById(Guid statusZalbeId)
        {
            return Context.StatusZalbe.FirstOrDefault(e => e.StatusZalbeID == statusZalbeId);
        }

        public List<StatusZalbe> GetStatusZalbeList()
        {
            return Context.StatusZalbe.ToList();
        }
    }
}