using AutoMapper;
using ParcelaService.Entities;
using ParcelaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParcelaService.Data
{
    public class ParcelaRepository : IParcelaRepository
    {
        private readonly ParcelaContext Context;
        private readonly IMapper Mapper;

        public ParcelaRepository(ParcelaContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public List<Parcela> GetParcelaList()
        {
            return Context.Parcela.ToList();
        }

        public Parcela GetParcelaById(Guid parcelaId)
        {
            return Context.Parcela.FirstOrDefault(e => e.ParcelaID == parcelaId);
        }

        public ParcelaConfirmationDto CreateParcela(Parcela parcela)
        {
            parcela.ParcelaID = Guid.NewGuid();

            Context.Parcela.Add(parcela);
            Context.SaveChanges();

            return Mapper.Map<ParcelaConfirmationDto>(parcela);
        }

        public ParcelaConfirmationDto UpdateParcela(Parcela parcela)
        {
            Parcela p = Context.Parcela.FirstOrDefault(e => e.ParcelaID == parcela.ParcelaID);

            if (p == null)
            {
                throw new EntryPointNotFoundException();
            }

            p.KorisnikParceleID = parcela.KorisnikParceleID;
            p.Povrsina = parcela.Povrsina;
            p.BrojParcele = parcela.BrojParcele;
            p.KatastarskaOpstinaID = parcela.KatastarskaOpstinaID;
            p.BrojListaNepokretnosti = parcela.BrojListaNepokretnosti;
            p.KulturaID = parcela.KulturaID;
            p.KlasaID = parcela.KlasaID;
            p.ObradivostID = parcela.ObradivostID;
            p.ZasticenaZonaID = parcela.ZasticenaZonaID;
            p.OblikSvojineID = parcela.OblikSvojineID;
            p.OdvodnjavanjeID = parcela.OdvodnjavanjeID;
            p.KulturaStvarnoStanje = parcela.KulturaStvarnoStanje;
            p.KlasaStvarnoStanje = parcela.KlasaStvarnoStanje;
            p.ObradivostStvarnoStanje = parcela.ObradivostStvarnoStanje;
            p.ZasticenaZonaStvarnoStanje = parcela.ZasticenaZonaStvarnoStanje;
            p.OdvodnjavanjeStvarnoStanje = parcela.OdvodnjavanjeStvarnoStanje;

            Context.SaveChanges();

            return Mapper.Map<ParcelaConfirmationDto>(p);
        }

        public ParcelaConfirmationDto DeleteParcela(Guid parcelaId)
        {
            Parcela parcela = GetParcelaById(parcelaId);

            if (parcela == null)
            {
                throw new ArgumentNullException("parcela", "Entity Parcela does not exist");
            }

            Context.Parcela.Remove(parcela);
            Context.SaveChanges();

            return Mapper.Map<ParcelaConfirmationDto>(parcela);
        }
    }
}
