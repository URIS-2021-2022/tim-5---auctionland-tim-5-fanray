using AdresaService.Data;
using AdresaService.Entities;
using AdresaService.Models;
using AdresaService.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaService.Controllers
{
    [ApiController]
    [Route("api/v1/adresa")]
    [Produces("application/json")]
    [Authorize]
    public class AdresaController : ControllerBase
    {
        private readonly IAdresaRepository AdresaRepository;
        private readonly IDrzavaRepository DrzavaRepository;
        private readonly LinkGenerator LinkGenerator;
        private readonly IMapper Mapper;
        private readonly ILoggerService LoggerService;

        public AdresaController(
            IAdresaRepository adresaRepository, 
            IDrzavaRepository drzavaRepository,
            LinkGenerator linkGenerator, 
            IMapper mapper, 
            ILoggerService loggerService)
        {
            this.AdresaRepository = adresaRepository;
            this.DrzavaRepository = drzavaRepository;
            this.LinkGenerator = linkGenerator;
            this.Mapper = mapper;
            this.LoggerService = loggerService;
        }

        /// <summary>
        /// Vraca listu svih adresa
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca listu svih adresa</response>
        /// <response code="204">Nema adresa</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<AdresaDto>> GetAdresaList()
        {
            List<Adresa> adresaList = AdresaRepository.GetAdresaList();

            if (adresaList == null || adresaList.Count == 0)
            {
                return NoContent();
            }

            foreach (Adresa a in adresaList)
            {
                a.Drzava = DrzavaRepository.GetDrzavaById(a.DrzavaID);
            }

            LoggerService.createLogAsync("Adresa", "Adresa", "GET", 200);

            return Ok(Mapper.Map<List<AdresaDto>>(adresaList));
        }

        /// <summary>
        /// Vraca adresu sa trazenim ID-em
        /// </summary>
        /// <param name="adresaId">Sifra adrese</param>
        /// <returns></returns>
        /// <response code="200">Vraca trazenu adresu</response>
        /// <response code="404">Adresa nije pronadjena</response>
        [HttpGet("{adresaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AdresaDto> GetAdresaById(Guid adresaId)
        {
            Adresa adresa = AdresaRepository.GetAdresaById(adresaId);

            if (adresa == null)
            {
                return NotFound();
            }

            adresa.Drzava = DrzavaRepository.GetDrzavaById(adresa.DrzavaID);

            LoggerService.createLogAsync("Adresa", "Adresa", "GET", 200);

            return Ok(Mapper.Map<AdresaDto>(adresa));
        }

        /// <summary>
        /// Upis nove adrese
        /// </summary>
        /// <returns></returns>
        /// <response code="201">Vraca kreiranu adresu</response>
        /// <response code="500">Doslo je do greske na serveru prilikom kreiranja adrese</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<AdresaConfirmationDto> CreateAdresa([FromBody] AdresaCreateDto adresaDto)
        {
            try
            {
                Adresa adresa = Mapper.Map<Adresa>(adresaDto);
                AdresaConfirmationDto confirmation = AdresaRepository.CreateAdresa(adresa);

                string location = LinkGenerator.GetPathByAction("GetAdresaById", "Adresa", new { adresaId = confirmation.AdresaID });

                LoggerService.createLogAsync("Adresa", "Adresa", "POST", 201);

                return Created(location, Mapper.Map<AdresaConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                LoggerService.createLogAsync("Adresa", "Adresa", "POST", 500);

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Azuriranje postojece adrese
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca azuriranu adresu</response>
        /// <response code="404">Adresa nije pronadjena</response>
        /// <response code="500">Doslo je do greske na serveru prilikom azuriranja adrese</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<AdresaConfirmationDto> UpdateAdresa(AdresaUpdateDto adresaDto)
        {
            try
            {
                Adresa oldAdresa = AdresaRepository.GetAdresaById(adresaDto.AdresaID);

                if (oldAdresa == null)
                {
                    return NotFound();
                }

                Adresa adresa = Mapper.Map<Adresa>(adresaDto);

                Mapper.Map(adresa, oldAdresa);

                AdresaConfirmationDto confirmation = AdresaRepository.UpdateAdresa(adresa);

                LoggerService.createLogAsync("Adresa", "Adresa", "PUT", 200);

                return Ok(Mapper.Map<AdresaConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                LoggerService.createLogAsync("Adresa", "Adresa", "PUT", 500);

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
        /// <summary>
        /// Brisanje adrese sa trazenim ID-em
        /// </summary>
        /// <param name="adresaId">Sifra adrese</param>
        /// <returns></returns>
        /// <response code="200">Vraca izbrisanu adresu</response>
        /// <response code="404">Adresa nije pronadjena</response>
        /// <response code="500">Doslo je do greske na serveru prilikom brisanja adrese</response>
        [HttpDelete("{adresaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<AdresaConfirmationDto> DeleteAdresa(Guid adresaId)
        {
            try
            {
                Adresa adresa = AdresaRepository.GetAdresaById(adresaId);

                if (adresa == null)
                {
                    return NotFound();
                }

                AdresaConfirmationDto confirmation = AdresaRepository.DeleteAdresa(adresaId);

                LoggerService.createLogAsync("Adresa", "Adresa", "DELETE", 200);

                return Ok(Mapper.Map<AdresaConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                LoggerService.createLogAsync("Adresa", "Adresa", "DELETE", 500);

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
