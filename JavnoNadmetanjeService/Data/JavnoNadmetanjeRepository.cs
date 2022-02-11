using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JavnoNadmetanjeService.Models;
using JavnoNadmetanjeService.Entities;
using AutoMapper;

namespace JavnoNadmetanjeService.Data
{
    public class JavnoNadmetanjeRepository : IJavnoNadmetanjeRepository
    {
        private readonly JavnoNadmetanjeContext Context;
        private readonly IMapper Mapper;

        public JavnoNadmetanjeRepository(JavnoNadmetanjeContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public JavnoNadmetanjeConfirmationDto CreateJavnoNadmetanje(JavnoNadmetanje javnoNadmetanje)
        {
            javnoNadmetanje.JavnoNadmetanjeId = Guid.NewGuid();

            Context.JavnoNadmetanje.Add(javnoNadmetanje);
            Context.SaveChanges();

            return Mapper.Map<JavnoNadmetanjeConfirmationDto>(javnoNadmetanje);
        }

        public JavnoNadmetanjeConfirmationDto DeleteJavnoNadmetanje(Guid javnoNadmetanjeId)
        {
            JavnoNadmetanje javnoNadmetanje = GetJavnoNadmetanjeById(javnoNadmetanjeId);

            if (javnoNadmetanje == null)
            {
                throw new ArgumentNullException("javnoNadmetanjeId");
            }

            Context.JavnoNadmetanje.Remove(javnoNadmetanje);
            Context.SaveChanges();

            return Mapper.Map<JavnoNadmetanjeConfirmationDto>(javnoNadmetanje);
        }

        public List<JavnoNadmetanje> GetJavnoNadmetanjeList()
        {
            return Context.JavnoNadmetanje.ToList();
        }

        public JavnoNadmetanje GetJavnoNadmetanjeById(Guid javnoNadmetanjeId)
        {
            return Context.JavnoNadmetanje.FirstOrDefault(e => e.JavnoNadmetanjeId == javnoNadmetanjeId);
        }

        public JavnoNadmetanjeConfirmationDto UpdateJavnoNadmetanje(JavnoNadmetanje javnoNadmetanje)
        {
            JavnoNadmetanje jn = Context.JavnoNadmetanje.FirstOrDefault(e => e.JavnoNadmetanjeId == javnoNadmetanje.JavnoNadmetanjeId);

            if (jn == null)
            {
                throw new EntryPointNotFoundException();
            }

            jn.JavnoNadmetanjeId = javnoNadmetanje.JavnoNadmetanjeId;
            jn.KatastarskaOpstinaId = javnoNadmetanje.KatastarskaOpstinaId;
            jn.TipJavnogNadmetanjaId = javnoNadmetanje.TipJavnogNadmetanjaId;
            jn.StatusJavnogNadmetanjaId = javnoNadmetanje.StatusJavnogNadmetanjaId;
            jn.Datum = javnoNadmetanje.Datum;
            jn.VremePocetka = javnoNadmetanje.VremePocetka;
            jn.VremeKraja = javnoNadmetanje.VremeKraja;
            jn.PocetnaCenaHektar = javnoNadmetanje.PocetnaCenaHektar;
            jn.Izuzeto = javnoNadmetanje.Izuzeto;
            jn.IzlicitiranaCena = javnoNadmetanje.IzlicitiranaCena;
            jn.PeriodZakupa = javnoNadmetanje.PeriodZakupa;
            jn.BrojUcesnika = javnoNadmetanje.BrojUcesnika;
            jn.VisinaDopuneDepozita = javnoNadmetanje.VisinaDopuneDepozita;
            jn.Krug = javnoNadmetanje.Krug;

            Context.SaveChanges();

            return Mapper.Map<JavnoNadmetanjeConfirmationDto>(jn);
        }
    }
}
