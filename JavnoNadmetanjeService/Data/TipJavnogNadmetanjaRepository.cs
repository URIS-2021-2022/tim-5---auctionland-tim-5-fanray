using AutoMapper;
using JavnoNadmetanjeService.Entities;
using JavnoNadmetanjeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanjeService.Data
{
    public class TipJavnogNadmetanjaRepository : ITipJavnogNadmetanjaRepository
    {
        private readonly JavnoNadmetanjeContext Context;
        private readonly IMapper Mapper;

        public TipJavnogNadmetanjaRepository(JavnoNadmetanjeContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public TipJavnogNadmetanjaConfirmationDto CreateTipJavnogNadmetanja(TipJavnogNadmetanja tipJavnogNadmetanja)
        {
            tipJavnogNadmetanja.TipJavnogNadmetanjaId = Guid.NewGuid();

            Context.TipJavnogNadmetanja.Add(tipJavnogNadmetanja);
            Context.SaveChanges();

            return Mapper.Map<TipJavnogNadmetanjaConfirmationDto>(tipJavnogNadmetanja);
        }

        public TipJavnogNadmetanjaConfirmationDto DeleteTipJavnogNadmetanja(Guid tipJavnogNadmetanjaId)
        {
            TipJavnogNadmetanja tipJavnogNadmetanja = GetTipJavnogNadmetanjaById(tipJavnogNadmetanjaId);

            if (tipJavnogNadmetanja == null)
            {
                throw new ArgumentNullException("tipJavnogNadmetanjaId");
            }

            Context.TipJavnogNadmetanja.Remove(tipJavnogNadmetanja);
            Context.SaveChanges();

            return Mapper.Map<TipJavnogNadmetanjaConfirmationDto>(tipJavnogNadmetanja);
        }

        public TipJavnogNadmetanja GetTipJavnogNadmetanjaById(Guid tipJavnogNadmetanjaId)
        {
            return Context.TipJavnogNadmetanja.FirstOrDefault(e => e.TipJavnogNadmetanjaId == tipJavnogNadmetanjaId);
        }

        public List<TipJavnogNadmetanja> GetTipJavnogNadmetanjaList()
        {
            return Context.TipJavnogNadmetanja.ToList();
        }

        public TipJavnogNadmetanjaConfirmationDto UpdateTipJavnogNadmetanja(TipJavnogNadmetanja tipJavnogNadmetanja)
        {
            TipJavnogNadmetanja tjn = Context.TipJavnogNadmetanja.FirstOrDefault(e => e.TipJavnogNadmetanjaId == tipJavnogNadmetanja.TipJavnogNadmetanjaId);

            if (tjn == null)
            {
                throw new EntryPointNotFoundException();
            }

            tjn.TipJavnogNadmetanjaId = tipJavnogNadmetanja.TipJavnogNadmetanjaId;
            tjn.NazivTipaJavnogNadmetanja = tipJavnogNadmetanja.NazivTipaJavnogNadmetanja;

            Context.SaveChanges();

            return Mapper.Map<TipJavnogNadmetanjaConfirmationDto>(tjn);
        }
    }
}
