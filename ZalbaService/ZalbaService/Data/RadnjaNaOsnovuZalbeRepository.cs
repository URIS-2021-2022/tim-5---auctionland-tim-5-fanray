using ZalbaService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZalbaService.Data
{
    public class RadnjaNaOsnovuZalbeRepository : IRadnjaNaOsnovuZalbeRepository
    {
        private readonly ZalbaContext Context;

        public RadnjaNaOsnovuZalbeRepository(ZalbaContext context)
        {
            this.Context = context;
        }

        public RadnjaNaOsnovuZalbe GetRadnjaNaOsnovuZalbeById(Guid radnjaNaOsnovuZalbeId)
        {
            return Context.RadnjaNaOsnovuZalbe.FirstOrDefault(e => e.RadnjaNaOsnovuZalbeID == radnjaNaOsnovuZalbeId);
        }

        public List<RadnjaNaOsnovuZalbe> GetRadnjaNaOsnovuZalbeList()
        {
            return Context.RadnjaNaOsnovuZalbe.ToList();
        }
    }
}