using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicnostService.Entities;
using LicnostService.Models;
using AutoMapper;

namespace LicnostService.Data
{
    public class PredsednikRepository : IPredsednikRepository
    {
        private readonly LicnostContext Context;
        private readonly IMapper Mapper;

        public PredsednikRepository(LicnostContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public PredsednikConfirmationDto CreatePredsednik(Predsednik predsednik)
        {
            predsednik.PredsednikID = Guid.NewGuid();

            Context.Predsednik.Add(predsednik);
            Context.SaveChanges();

            return Mapper.Map<PredsednikConfirmationDto>(predsednik);
        }

        public PredsednikConfirmationDto DeletePredsednik(Guid predsednikId)
        {
            Predsednik predsednik = GetPredsednikById(predsednikId);

            if (predsednik == null)
            {
                throw new ArgumentNullException("predsednikId");
            }

            Context.Predsednik.Remove(predsednik);
            Context.SaveChanges();

            return Mapper.Map<PredsednikConfirmationDto>(predsednik);
        }

        public Predsednik GetPredsednikById(Guid predsednikId)
        {
            return Context.Predsednik.FirstOrDefault(e => e.PredsednikID == predsednikId);
        }

        public List<Predsednik> GetPredsednikList(Guid licnostId)
        {
            return Context.Predsednik.Where(e => e.LicnostID == licnostId).ToList();
        }
        public PredsednikConfirmationDto UpdatePredsednik(Predsednik predsednik)
        {
            Predsednik dp = Context.Predsednik.FirstOrDefault(e => e.PredsednikID == predsednik.PredsednikID);

            if (dp == null)
            {
                throw new EntryPointNotFoundException();
            }

            dp.PredsednikID = predsednik.PredsednikID;

            Context.SaveChanges();

            return Mapper.Map<PredsednikConfirmationDto>(dp);
        }
    }
}
