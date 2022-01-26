using ParcelaService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParcelaService.Data
{
    public class KlasaRepository : IKlasaRepository
    {
        private readonly KlasaContext Context;

        public KlasaRepository(KlasaContext context)
        {
            this.Context = context;
        }

        public List<Klasa> GetKlasaList()
        {
            return Context.KlasaSet.ToList();
        }

        public Klasa GetKlasaById(Guid klasaId)
        {
            return Context.KlasaSet.FirstOrDefault(e => e.KlasaID == klasaId);
        }
    }
}
