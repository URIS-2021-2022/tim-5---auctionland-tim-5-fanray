using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OvlascenoLiceService.Entities;

namespace OvlascenoLiceService.Data
{
    public interface IBrojTableRepository
    {
        List<BrojTable> GetBrojTableList();
        BrojTable GetBrojTableById(Guid brojTableId);
    }
}