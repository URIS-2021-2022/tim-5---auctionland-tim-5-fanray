using AutoMapper;
using JavnoNadmetanjeService.Entities;
using JavnoNadmetanjeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanjeService.Data
{
    public class KatastarskaOpstinaRepository : IKatastarskaOpstinaRepository
    {
        private readonly JavnoNadmetanjeContext Context;
        private readonly IMapper Mapper;

        public KatastarskaOpstinaRepository(JavnoNadmetanjeContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public KatastarskaOpstinaConfirmationDto CreateKatastarskaOpstina(KatastarskaOpstina katastarskaOpstina)
        {
            katastarskaOpstina.KatastarskaOpstinaId = Guid.NewGuid();

            Context.KatastarskaOpstina.Add(katastarskaOpstina);
            Context.SaveChanges();

            return Mapper.Map<KatastarskaOpstinaConfirmationDto>(katastarskaOpstina);
        }

        public KatastarskaOpstinaConfirmationDto DeleteKatastarskaOpstina(Guid katastarskaOpstinaId)
        {
            KatastarskaOpstina katastarskaOpstina = GetKatastarskaOpstinaById(katastarskaOpstinaId);

            if (katastarskaOpstina == null)
            {
                throw new ArgumentNullException("katastarskaOpstinaId");
            }

            Context.KatastarskaOpstina.Remove(katastarskaOpstina);
            Context.SaveChanges();

            return Mapper.Map<KatastarskaOpstinaConfirmationDto>(katastarskaOpstina);
        }

        public KatastarskaOpstina GetKatastarskaOpstinaById(Guid katastarskaOpstinaId)
        {
            return Context.KatastarskaOpstina.FirstOrDefault(e => e.KatastarskaOpstinaId == katastarskaOpstinaId);
        }

        public List<KatastarskaOpstina> GetKatastarskaOpstinaList()
        {
            return Context.KatastarskaOpstina.ToList();
        }

        public KatastarskaOpstinaConfirmationDto UpdateKatastarskaOpstina(KatastarskaOpstina katastarskaOpstina)
        {
            KatastarskaOpstina ko = Context.KatastarskaOpstina.FirstOrDefault(e => e.KatastarskaOpstinaId == katastarskaOpstina.KatastarskaOpstinaId);

            if (ko == null)
            {
                throw new EntryPointNotFoundException();
            }

            ko.KatastarskaOpstinaId = katastarskaOpstina.KatastarskaOpstinaId;
            ko.NazivKatastarskeOpstine = katastarskaOpstina.NazivKatastarskeOpstine;

            Context.SaveChanges();

            return Mapper.Map<KatastarskaOpstinaConfirmationDto>(ko);
        }
    }
}
