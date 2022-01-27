using ParcelaService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParcelaService.Data
{
    public class KlasaRepository : IKlasaRepository
    {
        private readonly ParcelaContext Context;

        public KlasaRepository(ParcelaContext context)
        {
            this.Context = context;
        }

        public List<Klasa> GetKlasaList()
        {
            return Context.Klasa.ToList();
        }

        public Klasa GetKlasaById(Guid klasaId)
        {
            return Context.Klasa.FirstOrDefault(e => e.KlasaID == klasaId);
        }
    }
}
