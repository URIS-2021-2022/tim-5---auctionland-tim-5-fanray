using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuService.Data;
using UgovorOZakupuService.Entities;

namespace UgovorOZakupuService.Helpers
{
    public class UgovorHelper : IUgovorHelper
    {
        private readonly ITipGarancijeRepository TipGarancijeRepository;
        private readonly IRokRepository RokRepository;
        private readonly IDokumentRepository DokumentRepository;

        public UgovorHelper(
            ITipGarancijeRepository tipGarancijeRepository,
            IRokRepository rokRepository,
            IDokumentRepository dokumentRepository
        )
        {
            this.TipGarancijeRepository = tipGarancijeRepository;
            this.RokRepository = rokRepository;
            this.DokumentRepository = dokumentRepository;
        }

        public Ugovor loadRepositories(Ugovor ugovor)
        {
            ugovor.Dokument = DokumentRepository.GetDokumentById(ugovor.DokumentID);
            ugovor.Rok = RokRepository.GetRokById(ugovor.RokID);
            ugovor.TipGarancije = TipGarancijeRepository.GetTipGarancijeById(ugovor.TipGarancijeID);

            return ugovor;
        }
    }
}
