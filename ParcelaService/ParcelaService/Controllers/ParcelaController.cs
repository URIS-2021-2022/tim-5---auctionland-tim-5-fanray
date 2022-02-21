using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ParcelaService.Data;
using ParcelaService.Entities;
using ParcelaService.Models;
using ParcelaService.Services;
using System;
using System.Collections.Generic;

namespace ParcelaService.Controllers
{
    [ApiController]
    [Route("api/v1/parcela")]
    [Produces("application/json")]
    [Authorize]
    public class ParcelaController : ControllerBase
    {
        private readonly IParcelaRepository ParcelaRepository;
        private readonly IKatastarskaOpstinaRepository KatastarskaOpstinaRepository;
        private readonly IKlasaRepository KlasaRepository;
        private readonly IKulturaRepository KulturaRepository;
        private readonly IOblikSvojineRepository OblikSvojineRepository;
        private readonly IObradivostRepository ObradivostRepository;
        private readonly IOdvodnjavanjeRepository OdvodnjavanjeRepository;
        private readonly IZasticenaZonaRepository ZasticenaZonaRepository;
        private readonly LinkGenerator LinkGenerator;
        private readonly IMapper Mapper;
        private readonly ILoggerService LoggerService;

        public ParcelaController(
            IParcelaRepository parcelaRepository,
            IKatastarskaOpstinaRepository katastarskaOpstinaRepository,
            IKlasaRepository klasaRepository,
            IKulturaRepository kulturaRepository,
            IOblikSvojineRepository oblikSvojineRepository,
            IObradivostRepository obradivostRepository,
            IOdvodnjavanjeRepository odvodnjavanjeRepository,
            IZasticenaZonaRepository zasticenaZonaRepository,
            LinkGenerator linkGenerator, 
            IMapper mapper, 
            ILoggerService loggerService)
        {
            this.ParcelaRepository = parcelaRepository;
            this.KatastarskaOpstinaRepository = katastarskaOpstinaRepository;
            this.KlasaRepository = klasaRepository;
            this.KulturaRepository = kulturaRepository;
            this.OblikSvojineRepository = oblikSvojineRepository;
            this.ObradivostRepository = obradivostRepository;
            this.OdvodnjavanjeRepository = odvodnjavanjeRepository;
            this.ZasticenaZonaRepository = zasticenaZonaRepository;
            this.LinkGenerator = linkGenerator;
            this.Mapper = mapper;
            this.LoggerService = loggerService;
        }

        /// <summary>
        /// Vraca listu svih parcela
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca listu svih parcela</response>
        /// <response code="204">Nema parcela</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<ParcelaDto>> GetParcelaList()
        {
            List<Parcela> parcelaList = ParcelaRepository.GetParcelaList();

            if (parcelaList == null || parcelaList.Count == 0)
            {
                return NoContent();
            }

            foreach (Parcela p in parcelaList)
            {
                p.KatastarskaOpstina = KatastarskaOpstinaRepository.GetKatastarskaOpstinaById(p.KatastarskaOpstinaID);
                p.Klasa = KlasaRepository.GetKlasaById(p.KlasaID);
                p.Kultura = KulturaRepository.GetKulturaById(p.KulturaID);
                p.OblikSvojine = OblikSvojineRepository.GetOblikSvojineById(p.OblikSvojineID);
                p.Obradivost = ObradivostRepository.GetObradivostById(p.ObradivostID);
                p.Odvodnjavanje = OdvodnjavanjeRepository.GetOdvodnjavanjeById(p.OdvodnjavanjeID);
                p.ZasticenaZona = ZasticenaZonaRepository.GetZasticenaZonaById(p.ZasticenaZonaID);
            }

            return Ok(Mapper.Map<List<ParcelaDto>>(parcelaList));
        }

        /// <summary>
        /// Vraca parcelu sa trazenim ID-em
        /// </summary>
        /// <param name="parcelaId">Sifra parcele</param>
        /// <returns></returns>
        /// <response code="200">Vraca trazenu parcelu</response>
        /// <response code="404">Parcela nije pronadjena</response>
        [HttpGet("{parcelaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ParcelaDto> GetParcelaById(Guid parcelaId)
        {
            Parcela p = ParcelaRepository.GetParcelaById(parcelaId);

            if (p == null)
            {
                return NotFound();
            }

            p.KatastarskaOpstina = KatastarskaOpstinaRepository.GetKatastarskaOpstinaById(p.KatastarskaOpstinaID);
            p.Klasa = KlasaRepository.GetKlasaById(p.KlasaID);
            p.Kultura = KulturaRepository.GetKulturaById(p.KulturaID);
            p.OblikSvojine = OblikSvojineRepository.GetOblikSvojineById(p.OblikSvojineID);
            p.Obradivost = ObradivostRepository.GetObradivostById(p.ObradivostID);
            p.Odvodnjavanje = OdvodnjavanjeRepository.GetOdvodnjavanjeById(p.OdvodnjavanjeID);
            p.ZasticenaZona = ZasticenaZonaRepository.GetZasticenaZonaById(p.ZasticenaZonaID);

            return Ok(Mapper.Map<ParcelaDto>(p));
        }


        /// <summary>
        /// Upis nove parcele
        /// </summary>
        /// <returns></returns>
        /// <response code="201">Vraca kreiranu parcelu</response>
        /// <response code="500">Doslo je do greske na serveru prilikom kreiranja parcele</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ParcelaConfirmationDto> CreateParcela([FromBody] ParcelaCreateDto parcelaDto)
        {
            try
            {
                Parcela parcela = Mapper.Map<Parcela>(parcelaDto);
                ParcelaConfirmationDto confirmation = ParcelaRepository.CreateParcela(parcela);

                string location = LinkGenerator.GetPathByAction("GetParcelaById", "Parcela", new { parcelaId = confirmation.ParcelaID });

                LoggerService.createLogAsync("Parcela " + parcela.ParcelaID + " je dodata");

                return Created(location, Mapper.Map<ParcelaConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Azuriranje postojece parcele
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca azuriranu parcelu</response>
        /// <response code="404">Parcela nije pronadjena</response>
        /// <response code="500">Doslo je do greske na serveru prilikom azuriranja parcele</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ParcelaConfirmationDto> UpdateParcela(ParcelaUpdateDto parcelaDto)
        {
            try
            {
                Parcela oldParcela = ParcelaRepository.GetParcelaById(parcelaDto.ParcelaID);

                if (oldParcela == null)
                {
                    return NotFound();
                }

                Parcela parcela = Mapper.Map<Parcela>(parcelaDto);

                Mapper.Map(parcela, oldParcela);

                ParcelaConfirmationDto confirmation = ParcelaRepository.UpdateParcela(parcela);

                LoggerService.createLogAsync("Parcela " + parcela.ParcelaID + " je ažurirana");

                return Ok(Mapper.Map<ParcelaConfirmationDto>(confirmation));
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Brisanje parcele sa trazenim ID-em
        /// </summary>
        /// <param name="parcelaId">Sifra parcele</param>
        /// <returns></returns>
        /// <response code="200">Vraca izbrisanu parcelu</response>
        /// <response code="404">Parcela nije pronadjena</response>
        /// <response code="500">Doslo je do greske na serveru prilikom brisanja parcele</response>
        [HttpDelete("{parcelaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ParcelaConfirmationDto> DeleteParcela(Guid parcelaId)
        {
            try
            {
                Parcela parcela = ParcelaRepository.GetParcelaById(parcelaId);

                if (parcela == null)
                {
                    return NotFound();
                }

                ParcelaConfirmationDto confirmation = ParcelaRepository.DeleteParcela(parcelaId);

                LoggerService.createLogAsync("Parcela " + parcela.ParcelaID + " je izbrisana");

                return Ok(Mapper.Map<ParcelaConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpOptions]
        [AllowAnonymous] 
        public IActionResult GetExamRegistrationOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");

            return Ok();
        }
    }
}
