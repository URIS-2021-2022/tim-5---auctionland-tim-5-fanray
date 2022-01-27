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

        public ParcelaConfirmationDto CreateParcela(ParcelaCreateDto parcelaDto)
        {
            Parcela parcela = new Parcela()
            {
                ParcelaID = Guid.NewGuid(),
                KorisnikParceleID = parcelaDto.KorisnikParceleID,
                Povrsina = parcelaDto.Povrsina,
                BrojParcele = parcelaDto.BrojParcele,
                KatastarskaOpstinaID = parcelaDto.KatastarskaOpstinaID,
                BrojListaNepokretnosti = parcelaDto.BrojListaNepokretnosti,
                KulturaID = parcelaDto.KulturaID,
                KlasaID = parcelaDto.KlasaID,
                ObradivostID = parcelaDto.ObradivostID,
                ZasticenaZonaID = parcelaDto.ZasticenaZonaID,
                OblikSvojineID = parcelaDto.OblikSvojineID,
                OdvodnjavanjeID = parcelaDto.OdvodnjavanjeID,
                KulturaStvarnoStanje = parcelaDto.KulturaStvarnoStanje,
                KlasaStvarnoStanje = parcelaDto.KlasaStvarnoStanje,
                ObradivostStvarnoStanje = parcelaDto.ObradivostStvarnoStanje,
                ZasticenaZonaStvarnoStanje = parcelaDto.ZasticenaZonaStvarnoStanje,
                OdvodnjavanjeStvarnoStanje = parcelaDto.OdvodnjavanjeStvarnoStanje
            };

            Context.Add(parcela);
            Context.SaveChanges();

            return Mapper.Map<ParcelaConfirmationDto>(parcela);
        }

        public ParcelaConfirmationDto UpdateParcela(ParcelaUpdateDto parcelaDto)
        {
            Parcela parcela = Context.Parcela.FirstOrDefault(e => e.ParcelaID == parcelaDto.ParcelaID);

            if (parcela == null)
            {
                throw new EntryPointNotFoundException();
            }

            parcela.KorisnikParceleID = parcelaDto.KorisnikParceleID;
            parcela.Povrsina = parcelaDto.Povrsina;
            parcela.BrojParcele = parcelaDto.BrojParcele;
            parcela.KatastarskaOpstinaID = parcelaDto.KatastarskaOpstinaID;
            parcela.BrojListaNepokretnosti = parcelaDto.BrojListaNepokretnosti;
            parcela.KulturaID = parcelaDto.KulturaID;
            parcela.KlasaID = parcelaDto.KlasaID;
            parcela.ObradivostID = parcelaDto.ObradivostID;
            parcela.ZasticenaZonaID = parcelaDto.ZasticenaZonaID;
            parcela.OblikSvojineID = parcelaDto.OblikSvojineID;
            parcela.OdvodnjavanjeID = parcelaDto.OdvodnjavanjeID;
            parcela.KulturaStvarnoStanje = parcelaDto.KulturaStvarnoStanje;
            parcela.KlasaStvarnoStanje = parcelaDto.KlasaStvarnoStanje;
            parcela.ObradivostStvarnoStanje = parcelaDto.ObradivostStvarnoStanje;
            parcela.ZasticenaZonaStvarnoStanje = parcelaDto.ZasticenaZonaStvarnoStanje;
            parcela.OdvodnjavanjeStvarnoStanje = parcelaDto.OdvodnjavanjeStvarnoStanje;

            Context.SaveChanges();

            return Mapper.Map<ParcelaConfirmationDto>(parcela);
        }

        public ParcelaConfirmationDto DeleteParcela(Guid parcelaId)
        {
            Parcela parcela = GetParcelaById(parcelaId);

            if (parcela == null)
            {
                throw new ArgumentNullException();
            }

            Context.Remove(parcela);
            Context.SaveChanges();

            return Mapper.Map<ParcelaConfirmationDto>(parcela);
        }
    }
}
