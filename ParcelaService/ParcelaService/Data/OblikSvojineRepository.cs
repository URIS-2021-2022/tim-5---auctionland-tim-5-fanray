using ParcelaService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParcelaService.Data
{
    public class OblikSvojineRepository : IOblikSvojineRepository
    {
        private readonly OblikSvojineContext Context;

        public OblikSvojineRepository(OblikSvojineContext context)
        {
            this.Context = context;
        }

        public List<OblikSvojine> GetOblikSvojineList()
        {
            return Context.OblikSvojineSet.ToList();
        }

        public OblikSvojine GetOblikSvojineById(Guid oblikSvojineId)
        {
            return Context.OblikSvojineSet.FirstOrDefault(e => e.OblikSvojineID == oblikSvojineId);
        }
    }
}
