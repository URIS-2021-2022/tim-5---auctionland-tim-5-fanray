using JavnoNadmetanjeService.Entities;
using JavnoNadmetanjeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanjeService.Data
{
    public interface ISluzbeniListRepository
    {
        List<SluzbeniList> GetSluzbeniListList();
        SluzbeniList GetSluzbeniListById(Guid sluzbeniListId);
        SluzbeniListConfirmationDto CreateSluzbeniList(SluzbeniList sluzbeniList);
        SluzbeniListConfirmationDto UpdateSluzbeniList(SluzbeniList sluzbeniList);
        SluzbeniListConfirmationDto DeleteSluzbeniList(Guid sluzbeniListId);


    }
}
