using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZalbaService.Entities;

namespace ZalbaService.Data
{
    public interface IStatusZalbeRepository
    {
        List<StatusZalbe> GetStatusZalbeList();
        StatusZalbe GetStatusZalbeById(Guid statusZalbeId);
    }
}