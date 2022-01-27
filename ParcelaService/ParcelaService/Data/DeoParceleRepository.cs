using AutoMapper;
using ParcelaService.Entities;
using ParcelaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParcelaService.Data
{
    public class DeoParceleRepository : IDeoParceleRepository
    {
        private readonly ParcelaContext Context;
        private readonly IMapper Mapper;

        public DeoParceleRepository(ParcelaContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public List<DeoParcele> GetDeoParceleList(Guid parcelaId)
        {
            return Context.DeoParcele.Where(e => e.ParcelaID == parcelaId).ToList();
        }

        public DeoParcele GetDeoParcelaById(Guid deoParceleId)
        {
            return Context.DeoParcele.FirstOrDefault(e => e.DeoParceleID == deoParceleId);
        }

        public DeoParceleConfirmationDto CreateDeoParcele(DeoParcele deoParcele)
        {
            deoParcele.DeoParceleID = Guid.NewGuid();

            Context.DeoParcele.Add(deoParcele);
            Context.SaveChanges();

            return Mapper.Map<DeoParceleConfirmationDto>(deoParcele);
        }

        public DeoParceleConfirmationDto UpdateDeoParcele(DeoParcele deoParcele)
        {
            DeoParcele dp = Context.DeoParcele.FirstOrDefault(e => e.DeoParceleID == deoParcele.DeoParceleID);

            if (dp == null)
            {
                throw new EntryPointNotFoundException();
            }

            dp.ParcelaID = deoParcele.ParcelaID;
            dp.NazivDelaParcele = deoParcele.NazivDelaParcele;

            Context.SaveChanges();

            return Mapper.Map<DeoParceleConfirmationDto>(dp);
        }

        public DeoParceleConfirmationDto DeleteDeoParcele(Guid deoParceleId)
        {
            DeoParcele deoParcele = GetDeoParcelaById(deoParceleId);

            if (deoParcele == null)
            {
                throw new ArgumentNullException();
            }

            Context.DeoParcele.Remove(deoParcele);
            Context.SaveChanges();

            return Mapper.Map<DeoParceleConfirmationDto>(deoParcele);
        }
    }
}
