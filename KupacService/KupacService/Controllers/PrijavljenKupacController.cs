using AutoMapper;
using KupacService.Data;
using KupacService.Entities;
using KupacService.Models;
using KupacService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacService.Controllers
{
    [ApiController]
    [Route("api/v1/prijavljen-kupac")]
    [Produces("application/json")]
    [Authorize]
    public class PrijavljenKupacController : ControllerBase
    {
        private readonly IPrijavljeniKupacRepository PrijavljenKupacRepository;
        private readonly LinkGenerator LinkGenerator;
        private readonly IMapper Mapper;
        private readonly ILoggerService LoggerService;

        public PrijavljenKupacController(
            IPrijavljeniKupacRepository prijavljenKupacRepository,
            LinkGenerator linkGenerator,
            IMapper mapper,
            ILoggerService loggerService)
        {
            this.PrijavljenKupacRepository = prijavljenKupacRepository;
            this.LinkGenerator = linkGenerator;
            this.Mapper = mapper;
            this.LoggerService = loggerService;
        }

        /// <summary>
        /// Vraca listu svih prijavljenih kupaca
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca listu svih prijavljenih kupaca</response>
        /// <response code="204">Nema prijavljenih kupaca</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<PrijavljenKupacDto>> GetPrijavljenKupacList()
        {
            List<PrijavljenKupac> prijavljenKupacList = PrijavljenKupacRepository.GetPrijavljen_KupacList();

            if (prijavljenKupacList == null || prijavljenKupacList.Count == 0)
            {
                return NoContent();
            }

            LoggerService.createLogAsync("Kupac", "PrijavljenKupac", "GET", 200);

            return Ok(Mapper.Map<List<PrijavljenKupacDto>>(prijavljenKupacList));
        }

        /// <summary>
        /// Vraca prijavljenog kupca sa trazenim ID-em
        /// </summary>
        /// <param name="prijavljenKupacId">Sifra kupca</param>
        /// <returns></returns>
        /// <response code="200">Vraca trazenog prijavljenog kupca</response>
        /// <response code="404">Prijavljen kupac nije pronadjen</response>
        [HttpGet("{prijavljenKupacId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KupacDto> GetPrijavljen_KupacById(Guid prijavljenKupacId)
        {
            PrijavljenKupac prijavljenKupac = PrijavljenKupacRepository.GetPrijavljen_KupacById(prijavljenKupacId);

            if (prijavljenKupac == null)
            {
                return NotFound();
            }

            LoggerService.createLogAsync("Kupac", "PrijavljenKupac", "GET", 200);

            return Ok(Mapper.Map<PrijavljenKupacDto>(prijavljenKupac));
        }

        /// <summary>
        /// Upis novog prijavljenog kupca
        /// </summary>
        /// <returns></returns>
        /// <response code="201">Vraca kreiranog prijavljenog kupca</response>
        /// <response code="500">Doslo je do greske na serveru prilikom kreiranja prijavljenog kupca</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PrijavljenKupacConfirmationDto> CreatePrijavljenKupac([FromBody] PrijavljenKupacCreateDto prijavljenKupacDto)
        {
            try
            {
                PrijavljenKupac prijavljenKupac = Mapper.Map<PrijavljenKupac>(prijavljenKupacDto);
                PrijavljenKupacConfirmationDto confirmation = PrijavljenKupacRepository.CreatePrijavljenKupac(prijavljenKupac);

                string location = LinkGenerator.GetPathByAction("GetPrijavljen_KupacById", "PrijavljenKupac", new { prijavljenKupacId = confirmation.PrijavljenKupacId });

                LoggerService.createLogAsync("Kupac", "PrijavljenKupac", "POST", 201);

                return Created(location, Mapper.Map<PrijavljenKupacConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                LoggerService.createLogAsync("Kupac", "PrijavljenKupac", "POST", 500);

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        /// <summary>
        /// Azuriranje postojeceg prijavljenog kupca
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca azuriranog prijavljenog kupca</response>
        /// <response code="404">Prijavljen kupac nije pronadjen </response>
        /// <response code="500">Doslo je do greske na serveru prilikom azuriranja prijavljenog kupca</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PrijavljenKupacConfirmationDto> UpdatePrijavljenKupac(PrijavljenKupacUpdateDto prijavljenKupacDto)
        {
            try
            {
                PrijavljenKupac oldprijavljenKupac = PrijavljenKupacRepository.GetPrijavljen_KupacById(prijavljenKupacDto.PrijavljenKupacId);

                if (oldprijavljenKupac == null)
                {
                    return NotFound();
                }

                PrijavljenKupac prijavljenKupac = Mapper.Map<PrijavljenKupac>(prijavljenKupacDto);

                Mapper.Map(prijavljenKupac, oldprijavljenKupac);

                PrijavljenKupacConfirmationDto confirmation = PrijavljenKupacRepository.UpdatePrijavljenKupac(prijavljenKupac);

                LoggerService.createLogAsync("Kupac", "PrijavljenKupac", "PUT", 200);

                return Ok(Mapper.Map<PrijavljenKupacConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                LoggerService.createLogAsync("Kupac", "PrijavljenKupac", "PUT", 500);

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Brisanje prijavljenog kupca sa trazenim ID-em
        /// </summary>
        /// <param name="prijavljenKupacId">Sifra prijavljenog kupca</param>
        /// <returns></returns>
        /// <response code="200">Vraca izbrisanog prijavljenog kupca</response>
        /// <response code="404">Prijavljen kupac nije pronadjen</response>
        /// <response code="500">Doslo je do greske na serveru prilikom brisanja prijavljenog kupca</response>
        [HttpDelete("{prijavljenKupacId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PrijavljenKupacConfirmationDto> DeletePrijavljenKupac(Guid prijavljenKupacId)
        {
            try
            {
                PrijavljenKupac prijavljenKupac = PrijavljenKupacRepository.GetPrijavljen_KupacById(prijavljenKupacId);

                if (prijavljenKupac == null)
                {
                    return NotFound();
                }

                PrijavljenKupacConfirmationDto confirmation = PrijavljenKupacRepository.DeletePrijavljenKupac(prijavljenKupacId);

                LoggerService.createLogAsync("Kupac", "PrijavljenKupac", "DELETE", 200);

                return Ok(Mapper.Map<PrijavljenKupacConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                LoggerService.createLogAsync("Kupac", "PrijavljenKupac", "DELETE", 500);

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
