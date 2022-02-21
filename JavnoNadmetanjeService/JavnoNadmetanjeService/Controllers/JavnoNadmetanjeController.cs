using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using JavnoNadmetanjeService.Data;
using JavnoNadmetanjeService.Models;
using JavnoNadmetanjeService.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using JavnoNadmetanjeService.Services;

namespace JavnoNadmetanjeService.Controllers
{
    [ApiController]
    [Route("api/v1/javno-nadmetanje")]
    [Produces("application/json")]
    [Authorize]
    public class JavnoNadmetanjeController : ControllerBase
    {
        private readonly IJavnoNadmetanjeRepository javnoNadmetanjeRepository;
        private readonly ITipJavnogNadmetanjaRepository tipJavnogNadmetanjaRepository;
        private readonly IStatusJavnogNadmetanjaRepository statusJavnogNadmetanjaRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly ILoggerService LoggerService;

        public JavnoNadmetanjeController(
            IJavnoNadmetanjeRepository javnoNadmetanjeRepository,
            ITipJavnogNadmetanjaRepository tipJavnogNadmetanjaRepository,
            IStatusJavnogNadmetanjaRepository statusJavnogNadmetanjaRepository,
            LinkGenerator linkGenerator, IMapper mapper,
            ILoggerService loggerService
            )
        {
            this.javnoNadmetanjeRepository = javnoNadmetanjeRepository;
            this.tipJavnogNadmetanjaRepository = tipJavnogNadmetanjaRepository;
            this.statusJavnogNadmetanjaRepository = statusJavnogNadmetanjaRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.LoggerService = loggerService;
        }

        /// <summary>
        /// Vraca listu svih javnih nadmetanja
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca listu svih javnih nadmetanja</response>
        /// <response code="204">Nema javnih nadmetanja</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<JavnoNadmetanjeDto>> GetJavnoNadmetanje()
        {
            List<JavnoNadmetanje> javnaNadmetanja = javnoNadmetanjeRepository.GetJavnoNadmetanjeList();
            if (javnaNadmetanja == null || javnaNadmetanja.Count == 0)
            {
                return NoContent();
            }

            foreach (JavnoNadmetanje jn in javnaNadmetanja)
            {
                jn.TipJavnogNadmetanja = tipJavnogNadmetanjaRepository.GetTipJavnogNadmetanjaById(jn.TipJavnogNadmetanjaId);
                jn.StatusJavnogNadmetanja = statusJavnogNadmetanjaRepository.GetStatusJavnogNadmetanjaById(jn.StatusJavnogNadmetanjaId);
            }


            return Ok(mapper.Map<List<JavnoNadmetanjeDto>>(javnaNadmetanja));
        }

        /// <summary>
        /// Vraca javno nadmetanje sa trazenim ID-em
        /// </summary>
        /// <param name="javnoNadmetanjeId">Sifra javnog nadmetanja</param>
        /// <returns></returns>
        /// <response code="200">Vraca trazeno javno nadmetanje</response>
        /// <response code="404">Javno nadmetanje nije pronadjeno</response>
        [HttpGet("{javnoNadmetanjeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<JavnoNadmetanjeDto> GetJavnoNadmetanjeById(Guid javnoNadmetanjeId)
        {
            JavnoNadmetanje javnoNadmetanje = javnoNadmetanjeRepository.GetJavnoNadmetanjeById(javnoNadmetanjeId);
            if (javnoNadmetanje == null)
            {
                return NotFound();
            }

            javnoNadmetanje.TipJavnogNadmetanja = tipJavnogNadmetanjaRepository.GetTipJavnogNadmetanjaById(javnoNadmetanje.TipJavnogNadmetanjaId);
            javnoNadmetanje.StatusJavnogNadmetanja = statusJavnogNadmetanjaRepository.GetStatusJavnogNadmetanjaById(javnoNadmetanje.StatusJavnogNadmetanjaId);

            return Ok(mapper.Map<JavnoNadmetanjeDto>(javnoNadmetanje));
        }

        /// <summary>
        /// Upis novog javnog nadmetanja
        /// </summary>
        /// <returns></returns>
        /// <response code="201">Vraca kreirano javno nadmetanje</response>
        /// <response code="500">Doslo je do greske na serveru prilikom kreiranja javnog nadmetanja</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<JavnoNadmetanjeConfirmationDto> CreateJavnoNadmetanje([FromBody] JavnoNadmetanjeCreateDto javnoNadmetanjeDto)
        {
            try
            {
                JavnoNadmetanje javnoNadmetanje = mapper.Map<JavnoNadmetanje>(javnoNadmetanjeDto);
                JavnoNadmetanjeConfirmationDto confirmation = javnoNadmetanjeRepository.CreateJavnoNadmetanje(javnoNadmetanje);
                string location = linkGenerator.GetPathByAction("GetJavnoNadmetanjeById", "JavnoNadmetanje", new { javnoNadmetanjeId = confirmation.JavnoNadmetanjeId });

                LoggerService.createLogAsync("JNadmetanje " + javnoNadmetanje.JavnoNadmetanjeId + " je dodato");

                return Created(location, mapper.Map<JavnoNadmetanjeConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }

        /// <summary>
        /// Brisanje javnog nadmetanja sa trazenim ID-em
        /// </summary>
        /// <param name="javnoNadmetanjeId">Sifra javnog nadmetanja</param>
        /// <returns></returns>
        /// <response code="200">Vraca izbrisano javno nadmetanje</response>
        /// <response code="404">Javno nadmetanje nije pronadjeno</response>
        /// <response code="500">Doslo je do greske na serveru prilikom brisanja javnog nadmetanja</response>
        [HttpDelete("{javnoNadmetanjeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteJavnoNadmetanje(Guid javnoNadmetanjeId)
        {
            try
            {
                JavnoNadmetanje javnoNadmetanje = javnoNadmetanjeRepository.GetJavnoNadmetanjeById(javnoNadmetanjeId);
                if (javnoNadmetanje == null)
                {
                    return NotFound();
                }
                JavnoNadmetanjeConfirmationDto confirmation = javnoNadmetanjeRepository.DeleteJavnoNadmetanje(javnoNadmetanjeId);

                LoggerService.createLogAsync("JNadmetanje " + javnoNadmetanje.JavnoNadmetanjeId + " je izbrisano");

                return Ok(mapper.Map<JavnoNadmetanjeConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Azuriranje postojeceg javnog nadmetanja
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca azurirano javno nadmetanje</response>
        /// <response code="404">Javno Nadmetanje nije pronadjeno</response>
        /// <response code="500">Doslo je do greske na serveru prilikom azuriranja</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<JavnoNadmetanjeConfirmationDto> UpdateJavnoNadmetanje(JavnoNadmetanjeUpdateDto javnoNadmetanjeDto)
        {
            try
            {
                JavnoNadmetanje oldJn = javnoNadmetanjeRepository.GetJavnoNadmetanjeById(javnoNadmetanjeDto.JavnoNadmetanjeId);

                if (oldJn == null)
                {
                    return NotFound();
                }

                JavnoNadmetanje jn = mapper.Map<JavnoNadmetanje>(javnoNadmetanjeDto);

                mapper.Map(jn, oldJn);

                JavnoNadmetanjeConfirmationDto confirmation = javnoNadmetanjeRepository.UpdateJavnoNadmetanje(jn);

                LoggerService.createLogAsync("JNadmetanje " + jn.JavnoNadmetanjeId + " je ažurirano");

                return Ok(mapper.Map<JavnoNadmetanjeConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetJavnoNadmetanjeOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");

            return Ok();
        }


    }
}
