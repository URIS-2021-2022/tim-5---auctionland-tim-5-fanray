/*using AutoMapper;
using ZalbaService.Entities;
//using ZalbaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ZalbaService.Data
{
    public class ZalbaRepository : IZalbaRepository
    {
       private readonly ZalbaContext Context;
        private readonly IMapper Mapper;

        public ZalbaRepository(ZalbaContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public List<Zalba> GetZalbaList()
        {
            return Context.Zalba.ToList();
        }

        public Zalba GetZalbaById(Guid zalbaId)
        {
            return Context.Zalba.FirstOrDefault(e => e.ZalbaID == zalbaId);
        }

        public ZalbaConfirmationDto CreateParcela(Zalba zalba)
        {
            zalba.ZalbaID = Guid.NewGuid();

            Context.Zalba.Add(zalba);
            Context.SaveChanges();

            return Mapper.Map<ZalbaConfirmationDto>(zalba);
        }

        public ZalbaConfirmationDto UpdateZalba(Zalba parcela)
        {
            Zalba p = Context.Zalba.FirstOrDefault(e => e.ZalbaID == parcela.ZalbaID);

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
                throw new ArgumentNullException("parcelaId");
            }

            Context.Parcela.Remove(parcela);
            Context.SaveChanges();

            return Mapper.Map<ParcelaConfirmationDto>(parcela);
        }
    }
}*/