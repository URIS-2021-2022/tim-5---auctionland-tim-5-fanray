using LiceService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceService.Data
{
    public interface IFizickoLiceRepository
    {
        List<FizickoLice> GetFizickoLiceList();
        FizickoLice GetFizickoLiceById(Guid fizickoLiceId);
    }
}
