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
        private readonly DeoParceleContext Context;
        private readonly IMapper Mapper;

        public List<DeoParcele> GetDeoParceleList(Guid parcelaId)
        {
            return Context.DeoParceleSet.Where(e => e.ParcelaID == parcelaId).ToList();
        }

        public DeoParcele GetDeoParcelaById(Guid deoParceleId)
        {
            return Context.DeoParceleSet.FirstOrDefault(e => e.DeoParceleID == deoParceleId);
        }

        public DeoParceleConfirmationDto CreateDeoParcele(DeoParceleCreateDto deoParceleDto)
        {
            DeoParcele deoParcele = new DeoParcele()
            {
                DeoParceleID = Guid.NewGuid(),
                ParcelaID = deoParceleDto.ParcelaID,
                NazivDelaParcele = deoParceleDto.NazivDelaParcele
            };

            Context.Add(deoParcele);
            Context.SaveChanges();

            return Mapper.Map<DeoParceleConfirmationDto>(deoParcele);
        }

        public DeoParceleConfirmationDto UpdateDeoParcele(DeoParceleUpdateDto deoParceleDto)
        {
            DeoParcele deoParcele = Context.DeoParceleSet.FirstOrDefault(e => e.DeoParceleID == deoParceleDto.DeoParceleID);

            if (deoParcele == null)
            {
                throw new EntryPointNotFoundException();
            }

            deoParcele.ParcelaID = deoParceleDto.ParcelaID;
            deoParcele.NazivDelaParcele = deoParceleDto.NazivDelaParcele;

            Context.SaveChanges();

            return Mapper.Map<DeoParceleConfirmationDto>(deoParcele);
        }

        public DeoParceleConfirmationDto DeleteDeoParcele(Guid deoParceleId)
        {
            DeoParcele deoParcele = GetDeoParcelaById(deoParceleId);

            if (deoParcele == null)
            {
                throw new ArgumentNullException();
            }

            Context.Remove(deoParceleId);
            Context.SaveChanges();

            return Mapper.Map<DeoParceleConfirmationDto>(deoParcele);
        }
    }
}
