using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZalbaService.Models;

namespace ZalbaService.Data
{
    public interface IKupacMockRepository
    {

        List<PrijavljeniKupacDto> GetPrijavljeniKupacList();
        PrijavljeniKupacDto GetPrijavljeniKupacById(Guid prijavljeniKupacId);
        List<NajboljiPonudjacDto> GetNajboljiPonudjacList();
        NajboljiPonudjacDto GetNajboljiPonudjacById(Guid najboljiPonudjacId);
        List<PrioritetDto> GetPrioritetList();
        PrioritetDto GetPrioritetById(Guid prioritetId);
    }
}
