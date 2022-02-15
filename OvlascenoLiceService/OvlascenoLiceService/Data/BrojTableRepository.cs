using OvlascenoLiceService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OvlascenoLiceService.Data
{
    public class BrojTableRepository : IBrojTableRepository
    {
        private readonly OvlascenoLiceContext Context;

        public BrojTableRepository(OvlascenoLiceContext context)
        {
            this.Context = context;
        }

        public BrojTable GetBrojTableById(Guid brojTableId)
        {
            return Context.BrojTable.FirstOrDefault(e => e.BrojTableID == brojTableId);
        }

        public List<BrojTable> GetBrojTableList()
        {
            return Context.BrojTable.ToList();
        }
    }
}