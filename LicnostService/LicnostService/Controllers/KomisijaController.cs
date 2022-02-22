using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using LicnostService.Data;
using LicnostService.Entities;
using LicnostService.Models;
using System;
using System.Collections.Generic;
using LicnostService.Services;

namespace LicnostService.Controllers
{
    [ApiController]
    [Route("api/v1/komisija")]
    [Produces("application/json")]
    [Authorize]
    public class KomisijaController : ControllerBase
    {
        private readonly IKomisijaRepository KomisijaRepository;
        private readonly LinkGenerator LinkGenerator;
        private readonly IMapper Mapper;
        private readonly ILoggerService LoggerService;
        public KomisijaController(IKomisijaRepository komisijaRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.KomisijaRepository = komisijaRepository;
            this.LinkGenerator = linkGenerator;
            this.Mapper = mapper;
            this.LoggerService = loggerService;
        }

        /// <response code="204">Nema kultura</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<KomisijaDto>> GetKomisijaList()
        {
            List<Komisija> komisijaList = KomisijaRepository.GetKomisijaList();

            if (komisijaList == null || komisijaList.Count == 0)
            {
                return NoContent();
            }

            LoggerService.createLogAsync("Licnost", "Komisija", "GET", 200);

            return Ok(Mapper.Map<List<KomisijaDto>>(komisijaList));
        }

        [HttpGet("{komisijaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KomisijaDto> GetKomisijaById(Guid komisijaId)
        {
            Komisija komisija = KomisijaRepository.GetKomisijaById(komisijaId);

            if (komisija == null)
            {
                return NotFound();
            }

            LoggerService.createLogAsync("Licnost", "Komisija", "GET", 200);

            return Ok(Mapper.Map<KomisijaDto>(komisija));
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KomisijaConfirmationDto> CreateKomisija([FromBody] KomisijaCreateDto komisijaDto)
        {
            try
            {
                Komisija komisija = Mapper.Map<Komisija>(komisijaDto);
                KomisijaConfirmationDto confirmation = KomisijaRepository.CreateKomisija(komisija);

                string location = LinkGenerator.GetPathByAction("GetKomisijaById", "Komisija", new { komisijaId = confirmation.KomisijaID });

                LoggerService.createLogAsync("Licnost", "Komisija", "POST", 201);

                return Created(location, Mapper.Map<KomisijaConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                LoggerService.createLogAsync("Licnost", "Komisija", "POST", 500);

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KomisijaConfirmationDto> UpdateKomisija(KomisijaUpdateDto komisijaDto)
        {
            try
            {
                Komisija oldKomisija = KomisijaRepository.GetKomisijaById(komisijaDto.KomisijaID);

                if (oldKomisija == null)
                {
                    return NotFound();
                }

                Komisija komisija = Mapper.Map<Komisija>(komisijaDto);

                Mapper.Map(komisija, oldKomisija);

                KomisijaConfirmationDto confirmation = KomisijaRepository.UpdateKomisija(komisija);

                LoggerService.createLogAsync("Licnost", "Komisija", "PUT", 200);

                return Ok(Mapper.Map<KomisijaConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {

                LoggerService.createLogAsync("Licnost", "Komisija", "PUT", 500);

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{komisijaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KomisijaConfirmationDto> DeleteKomisija(Guid komisijaId)
        {
            try
            {
                Komisija komisija = KomisijaRepository.GetKomisijaById(komisijaId);

                if (komisija == null)
                {
                    return NotFound();
                }

                KomisijaConfirmationDto confirmation = KomisijaRepository.DeleteKomisija(komisijaId);

                LoggerService.createLogAsync("Licnost", "Komisija", "DELETE", 200);

                return Ok(Mapper.Map<KomisijaConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                LoggerService.createLogAsync("Licnost", "Komisija", "DELETE", 500);

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
