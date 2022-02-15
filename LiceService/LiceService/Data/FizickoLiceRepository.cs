using LiceService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceService.Data
{
    public class FizickoLiceRepository :IFizickoLiceRepository
    {
        private readonly LiceContext Context;
        public FizickoLiceRepository(LiceContext context)
        {
            this.Context = context;
        }

        public FizickoLice GetFizickoLiceById(Guid fizickoLiceId)
        {
            return Context.FizickoLice.FirstOrDefault(e => e.JMBG == fizickoLiceId);
        }

        public List<FizickoLice> GetFizickoLiceList()
        {
            return Context.FizickoLice.ToList();
        }
    }
}
