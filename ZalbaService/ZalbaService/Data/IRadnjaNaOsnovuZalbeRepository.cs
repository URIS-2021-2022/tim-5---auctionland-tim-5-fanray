using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZalbaService.Entities;

namespace ZalbaService.Data
{
    public interface IRadnjaNaOsnovuZalbeRepository
    {
        List<RadnjaNaOsnovuZalbe> GetRadnjaNaOsnovuZalbeList();
        RadnjaNaOsnovuZalbe GetRadnjaNaOsnovuZalbeById(Guid radnjaNaOsnovuZalbeId);
    }
}