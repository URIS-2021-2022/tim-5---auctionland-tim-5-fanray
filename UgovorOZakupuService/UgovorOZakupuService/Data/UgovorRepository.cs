using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuService.Entities;
using UgovorOZakupuService.Models;

namespace UgovorOZakupuService.Data
{
    public class UgovorRepository : IUgovorRepository
    {
        private readonly UgovorContext Context;
        private readonly IMapper Mapper;

        public List<Ugovor> KorisnikList { get; set; } = new List<Ugovor>();

        public UgovorRepository(UgovorContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public List<Ugovor> GetUgovorList()
        {
            return Context.Ugovor.ToList();
        }

        public Ugovor GetUgovorById(Guid ugovorId)
        {
            return Context.Ugovor.FirstOrDefault(e => e.UgovorID == ugovorId);
        }

        public UgovorConfirmationDto CreateUgovor(Ugovor ugovor)
        {
            ugovor.UgovorID = Guid.NewGuid();

            Context.Ugovor.Add(ugovor);
            Context.SaveChanges();

            return Mapper.Map<UgovorConfirmationDto>(ugovor);
        }

        public UgovorConfirmationDto UpdateUgovor(Ugovor ugovor)
        {
            Ugovor u = Context.Ugovor.FirstOrDefault(e => e.UgovorID == ugovor.UgovorID);

            if (u == null)
            {
                throw new EntryPointNotFoundException();
            }

            u.TipGarancijeID = ugovor.TipGarancijeID;
            u.KorisnikID = ugovor.KorisnikID;
            u.DokumentID = ugovor.DokumentID;
            u.RokID = ugovor.RokID;
            u.KupacID = ugovor.KupacID;
            u.LicnostID = ugovor.LicnostID;
            u.JavnoNadmetanjeID = ugovor.JavnoNadmetanjeID;
            u.ZavodniBroj = ugovor.ZavodniBroj;
            u.DatumZavodjenja = ugovor.DatumZavodjenja;
            u.RokZaVracanjeZem = ugovor.RokZaVracanjeZem;
            u.MestoPotpisivanja = ugovor.MestoPotpisivanja;
            u.DatumPotpisa = ugovor.DatumPotpisa;

            Context.SaveChanges();

            return Mapper.Map<UgovorConfirmationDto>(u);
        }

        public UgovorConfirmationDto DeleteUgovor(Guid ugovorId)
        {
            Ugovor ugovor = GetUgovorById(ugovorId);

            if (ugovor == null)
            {
                throw new ArgumentNullException("ugovorId");
            }

            Context.Ugovor.Remove(ugovor);
            Context.SaveChanges();

            return Mapper.Map<UgovorConfirmationDto>(ugovor);
        }

    }
}
