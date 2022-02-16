using AutoMapper;
using JavnoNadmetanjeService.Data;
using JavnoNadmetanjeService.Entities;
using JavnoNadmetanjeService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavnoNadmetanjeService.Controllers
{
    [ApiController]
    [Route("api/v1/status-javnog-nadmetanja")]
    [Produces("application/json")]
    public class StatusJavnogNadmetanjaController : ControllerBase
    {
        private readonly IStatusJavnogNadmetanjaRepository statusJavnogNadmetanjaRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public StatusJavnogNadmetanjaController(IStatusJavnogNadmetanjaRepository statusJavnogNadmetanjaRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.statusJavnogNadmetanjaRepository = statusJavnogNadmetanjaRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraca listu svih statusa javnih nadmetanja
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca listu svih statusa javnih nadmetanja</response>
        /// <response code="204">Nema statusa javnih nadmetanja</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<StatusJavnogNadmetanjaDto>> GetStatusJavnogNadmetanja()
        {
            List<StatusJavnogNadmetanja> statusi = statusJavnogNadmetanjaRepository.GetStatusJavnogNadmetanjaList();
            if (statusi == null || statusi.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<StatusJavnogNadmetanjaDto>>(statusi));
        }

        /// <summary>
        /// Vraca status javnog nadmetanja sa trazenim ID-em
        /// </summary>
        /// <param name="statusJavnogNadmetanjaId">Sifra statusa javnog nadmetanja</param>
        /// <returns></returns>
        /// <response code="200">Vraca trazeni status javnog nadmetanja</response>
        /// <response code="404">Status javnog nadmetanja nije pronadjen</response>
        [HttpGet("{statusJavnogNadmetanjaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<StatusJavnogNadmetanjaDto> GetStatusJavnogNadmetanjaById(Guid statusJavnogNadmetanjaId)
        {
            StatusJavnogNadmetanja statusJavnogNadmetanja = statusJavnogNadmetanjaRepository.GetStatusJavnogNadmetanjaById(statusJavnogNadmetanjaId);
            if (statusJavnogNadmetanja == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<StatusJavnogNadmetanjaDto>(statusJavnogNadmetanja));
        }

        /// <summary>
        /// Upis novog statusa javnog nadmetanja
        /// </summary>
        /// <returns></returns>
        /// <response code="201">Vraca kreiran statusa javnog nadmetanja</response>
        /// <response code="500">Doslo je do greske na serveru prilikom kreiranja statusa javnog nadmetanja</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StatusJavnogNadmetanjaConfirmationDto> CreateStatusJavnogNadmetanja([FromBody] StatusJavnogNadmetanjaCreateDto statusJavnogNadmetanjaDto)
        {
            try
            {
                StatusJavnogNadmetanja statusJavnogNadmetanja = mapper.Map<StatusJavnogNadmetanja>(statusJavnogNadmetanjaDto);
                StatusJavnogNadmetanjaConfirmationDto confirmation = statusJavnogNadmetanjaRepository.CreateStatusJavnogNadmetanja(statusJavnogNadmetanja);
                string location = linkGenerator.GetPathByAction("GetStatusJavnogNadmetanjaById", "StatusJavnogNadmetanja", new { statusJavnogNadmetanjaId = confirmation.StatusJavnogNadmetanjaId });

                return Created(location, mapper.Map<StatusJavnogNadmetanjaConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        /// <summary>
        /// Brisanje statusa javnog nadmetanja sa trazenim ID-em
        /// </summary>
        /// <param name="statusJavnogNadmetanjaId">Sifra statusa javnog nadmetanja</param>
        /// <returns></returns>
        /// <response code="200">Vraca izbrisan status javnog nadmetanja</response>
        /// <response code="404">Status javnog nadmetanja nije pronadjen</response>
        /// <response code="500">Doslo je do greske na serveru prilikom brisanja</response>
        [HttpDelete("{statusJavnogNadmetanjaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteStatusJavnogNadmetanja(Guid statusJavnogNadmetanjaId)
        {
            try
            {
                StatusJavnogNadmetanja statusJavnogNadmetanja = statusJavnogNadmetanjaRepository.GetStatusJavnogNadmetanjaById(statusJavnogNadmetanjaId);
                if (statusJavnogNadmetanja == null)
                {
                    return NotFound();
                }
                StatusJavnogNadmetanjaConfirmationDto confirmation = statusJavnogNadmetanjaRepository.DeleteStatusJavnogNadmetanja(statusJavnogNadmetanjaId);
                return Ok(mapper.Map<StatusJavnogNadmetanjaConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Azuriranje postojeceg statusa javnog nadmetanja
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca azuriran status javnog nadmetanja</response>
        /// <response code="404">Status javnog nadmetanja nije pronadjen</response>
        /// <response code="500">Doslo je do greske na serveru prilikom azuriranja</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StatusJavnogNadmetanjaConfirmationDto> UpdateStatusJavnogNadmetanja(StatusJavnogNadmetanjaUpdateDto statusJavnogNadmetanjaDto)
        {
            try
            {
                StatusJavnogNadmetanja oldSjn = statusJavnogNadmetanjaRepository.GetStatusJavnogNadmetanjaById(statusJavnogNadmetanjaDto.StatusJavnogNadmetanjaId);

                if (oldSjn == null)
                {
                    return NotFound();
                }

                StatusJavnogNadmetanja Sjn = mapper.Map<StatusJavnogNadmetanja>(statusJavnogNadmetanjaDto);

                mapper.Map(Sjn, oldSjn);

                StatusJavnogNadmetanjaConfirmationDto confirmation = statusJavnogNadmetanjaRepository.UpdateStatusJavnogNadmetanja(Sjn);

                return Ok(mapper.Map<StatusJavnogNadmetanjaConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetStatusJavnogNadmetanjaOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");

            return Ok();
        }
    }
}