using ParcelaService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParcelaService.Data
{
    public class OblikSvojineRepository : IOblikSvojineRepository
    {
        private readonly ParcelaContext Context;

        public OblikSvojineRepository(ParcelaContext context)
        {
            this.Context = context;
        }

        public List<OblikSvojine> GetOblikSvojineList()
        {
            return Context.OblikSvojine.ToList();
        }

        public OblikSvojine GetOblikSvojineById(Guid oblikSvojineId)
        {
            return Context.OblikSvojine.FirstOrDefault(e => e.OblikSvojineID == oblikSvojineId);
        }
    }
}
