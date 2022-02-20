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
    [Route("api/v1/tip-javnog-nadmetanja")]
    [Produces("application/json")]
    [Authorize]
    public class TipJavnogNadmetanjaController : ControllerBase
    {
        private readonly ITipJavnogNadmetanjaRepository tipJavnogNadmetanjaRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public TipJavnogNadmetanjaController(ITipJavnogNadmetanjaRepository tipJavnogNadmetanjaRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.tipJavnogNadmetanjaRepository = tipJavnogNadmetanjaRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraca listu svih tipova javnih nadmetanja
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca listu svih tipova javnih nadmetanja</response>
        /// <response code="204">Nema tipova javnih nadmetanja</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<TipJavnogNadmetanjaDto>> GetTipJavnogNadmetanja()
        {
            List<TipJavnogNadmetanja> tipovi = tipJavnogNadmetanjaRepository.GetTipJavnogNadmetanjaList();
            if (tipovi == null || tipovi.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<TipJavnogNadmetanjaDto>>(tipovi));
        }

        /// <summary>
        /// Vraca tip javnog nadmetanja sa trazenim ID-em
        /// </summary>
        /// <param name="tipJavnogNadmetanjaId">Sifra tipa javnog nadmetanja</param>
        /// <returns></returns>
        /// <response code="200">Vraca trazeni tip javnog nadmetanja</response>
        /// <response code="404">Tip javnog nadmetanja nije pronadjen</response>
        [HttpGet("{tipJavnogNadmetanjaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<TipJavnogNadmetanjaDto> GetTipJavnogNadmetanjaById(Guid tipJavnogNadmetanjaId)
        {
            TipJavnogNadmetanja tipJavnogNadmetanja = tipJavnogNadmetanjaRepository.GetTipJavnogNadmetanjaById(tipJavnogNadmetanjaId);
            if (tipJavnogNadmetanja == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<TipJavnogNadmetanjaDto>(tipJavnogNadmetanja));
        }

        /// <summary>
        /// Upis novog tipa javnog nadmetanja
        /// </summary>
        /// <returns></returns>
        /// <response code="201">Vraca kreiran tip javnog nadmetanja</response>
        /// <response code="500">Doslo je do greske na serveru prilikom kreiranja tipa javnog nadmetanja</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TipJavnogNadmetanjaConfirmationDto> CreateTipJavnogNadmetanja([FromBody] TipJavnogNadmetanjaCreateDto tipJavnogNadmetanjaDto)
        {
            try
            {
                TipJavnogNadmetanja tipJavnogNadmetanja = mapper.Map<TipJavnogNadmetanja>(tipJavnogNadmetanjaDto);
                TipJavnogNadmetanjaConfirmationDto confirmation = tipJavnogNadmetanjaRepository.CreateTipJavnogNadmetanja(tipJavnogNadmetanja);
                string location = linkGenerator.GetPathByAction("GetTipJavnogNadmetanjaById", "TipJavnogNadmetanja", new { tipJavnogNadmetanjaId = confirmation.TipJavnogNadmetanjaId });

                return Created(location, mapper.Map<TipJavnogNadmetanjaConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        /// <summary>
        /// Brisanje tipa javnog nadmetanja sa trazenim ID-em
        /// </summary>
        /// <param name="tipJavnogNadmetanjaId">Sifra tipa javnog nadmetanja</param>
        /// <returns></returns>
        /// <response code="200">Vraca izbrisan tip javnog nadmetanja</response>
        /// <response code="404">Tip javnog nadmetanja nije pronadjen</response>
        /// <response code="500">Doslo je do greske na serveru prilikom brisanja</response>
        [HttpDelete("{tipJavnogNadmetanjaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteTipJavnogNadmetanja(Guid tipJavnogNadmetanjaId)
        {
            try
            {
                TipJavnogNadmetanja tipJavnogNadmetanja = tipJavnogNadmetanjaRepository.GetTipJavnogNadmetanjaById(tipJavnogNadmetanjaId);
                if (tipJavnogNadmetanja == null)
                {
                    return NotFound();
                }
                TipJavnogNadmetanjaConfirmationDto confirmation = tipJavnogNadmetanjaRepository.DeleteTipJavnogNadmetanja(tipJavnogNadmetanjaId);
                return Ok(mapper.Map<TipJavnogNadmetanjaConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Azuriranje postojeceg tipa javnog nadmetanja
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca azuriran tip javnog nadmetanja</response>
        /// <response code="404">Tip javnog nadmetanja nije pronadjen</response>
        /// <response code="500">Doslo je do greske na serveru prilikom azuriranja</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TipJavnogNadmetanjaConfirmationDto> UpdateTipJavnogNadmetanja(TipJavnogNadmetanjaUpdateDto tipJavnogNadmetanjaDto)
        {
            try
            {
                TipJavnogNadmetanja oldTjn = tipJavnogNadmetanjaRepository.GetTipJavnogNadmetanjaById(tipJavnogNadmetanjaDto.TipJavnogNadmetanjaId);

                if (oldTjn == null)
                {
                    return NotFound();
                }

                TipJavnogNadmetanja Tjn = mapper.Map<TipJavnogNadmetanja>(tipJavnogNadmetanjaDto);

                mapper.Map(Tjn, oldTjn);

                TipJavnogNadmetanjaConfirmationDto confirmation = tipJavnogNadmetanjaRepository.UpdateTipJavnogNadmetanja(Tjn);

                return Ok(mapper.Map<TipJavnogNadmetanjaConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetTipJavnogNadmetanjaOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");

            return Ok();
        }
    }
}
