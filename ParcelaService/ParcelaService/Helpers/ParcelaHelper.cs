using ParcelaService.Data;
using ParcelaService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaService.Helpers
{
    public class ParcelaHelper : IParcelaHelper
    {
        private readonly IKatastarskaOpstinaRepository KatastarskaOpstinaRepository;
        private readonly IKlasaRepository KlasaRepository;
        private readonly IKulturaRepository KulturaRepository;
        private readonly IOblikSvojineRepository OblikSvojineRepository;
        private readonly IObradivostRepository ObradivostRepository;
        private readonly IOdvodnjavanjeRepository OdvodnjavanjeRepository;
        private readonly IZasticenaZonaRepository ZasticenaZonaRepository;

        public ParcelaHelper(
            IKatastarskaOpstinaRepository katastarskaOpstinaRepository,
            IKlasaRepository klasaRepository,
            IKulturaRepository kulturaRepository,
            IOblikSvojineRepository oblikSvojineRepository,
            IObradivostRepository obradivostRepository,
            IOdvodnjavanjeRepository odvodnjavanjeRepository,
            IZasticenaZonaRepository zasticenaZonaRepository
        )
        {
            this.KatastarskaOpstinaRepository = katastarskaOpstinaRepository;
            this.KlasaRepository = klasaRepository;
            this.KulturaRepository = kulturaRepository;
            this.OblikSvojineRepository = oblikSvojineRepository;
            this.ObradivostRepository = obradivostRepository;
            this.OdvodnjavanjeRepository = odvodnjavanjeRepository;
            this.ZasticenaZonaRepository = zasticenaZonaRepository;
        }

        public Parcela loadRepositories(Parcela parcela)
        {
            parcela.KatastarskaOpstina = KatastarskaOpstinaRepository.GetKatastarskaOpstinaById(parcela.KatastarskaOpstinaID);
            parcela.Klasa = KlasaRepository.GetKlasaById(parcela.KlasaID);
            parcela.Kultura = KulturaRepository.GetKulturaById(parcela.KulturaID);
            parcela.OblikSvojine = OblikSvojineRepository.GetOblikSvojineById(parcela.OblikSvojineID);
            parcela.Obradivost = ObradivostRepository.GetObradivostById(parcela.ObradivostID);
            parcela.Odvodnjavanje = OdvodnjavanjeRepository.GetOdvodnjavanjeById(parcela.OdvodnjavanjeID);
            parcela.ZasticenaZona = ZasticenaZonaRepository.GetZasticenaZonaById(parcela.ZasticenaZonaID);

            return parcela;
        }
    }
}
