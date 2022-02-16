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
    [Route("api/v1/katastarska-opstina")]
    [Produces("application/json")]
    public class KatastarskaOpstinaController : ControllerBase
    {
        private readonly IKatastarskaOpstinaRepository katastarskaOpstinaRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public KatastarskaOpstinaController(IKatastarskaOpstinaRepository katastarskaOpstinaRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.katastarskaOpstinaRepository = katastarskaOpstinaRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraca listu svih katastarskih opstina
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca listu svih katastarskih opstina</response>
        /// <response code="204">Nema katastarskih opstina</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<KatastarskaOpstinaDto>> GetKatastarskaOpstina()
        {
            List<KatastarskaOpstina> katastarskeOpstine = katastarskaOpstinaRepository.GetKatastarskaOpstinaList();
            if (katastarskeOpstine == null || katastarskeOpstine.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<KatastarskaOpstinaDto>>(katastarskeOpstine));
        }

        /// <summary>
        /// Vraca katastarsku opstinu sa trazenim ID-em
        /// </summary>
        /// <param name="katastarskaOpstinaId">Sifra katastarske opstine</param>
        /// <returns></returns>
        /// <response code="200">Vraca trazenu katastarsku opstinu</response>
        /// <response code="404">Katastarska opstina nije pronadjena</response>
        [HttpGet("{katastarskaOpstinaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KatastarskaOpstinaDto> GetKatastarskaOpstinaById(Guid katastarskaOpstinaId)
        {
            KatastarskaOpstina katastarskaOpstina = katastarskaOpstinaRepository.GetKatastarskaOpstinaById(katastarskaOpstinaId);
            if (katastarskaOpstina == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<KatastarskaOpstinaDto>(katastarskaOpstina));
        }

        /// <summary>
        /// Upis nove katastarske opstine
        /// </summary>
        /// <returns></returns>
        /// <response code="201">Vraca kreiranu katastarsku opstinu</response>
        /// <response code="500">Doslo je do greske na serveru prilikom kreiranja katastarske opstine</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KatastarskaOpstinaConfirmationDto> CreateKatastarskaOpstina([FromBody] KatastarskaOpstinaCreateDto katastarskaOpstinaDto)
        {
            try
            {
                KatastarskaOpstina katastarskaOpstina = mapper.Map<KatastarskaOpstina>(katastarskaOpstinaDto);
                KatastarskaOpstinaConfirmationDto confirmation = katastarskaOpstinaRepository.CreateKatastarskaOpstina(katastarskaOpstina);
                string location = linkGenerator.GetPathByAction("GetKatastarskaOpstinaById", "KatastarskaOpstina", new { katastarskaOpstinaId = confirmation.KatastarskaOpstinaId });

                return Created(location, mapper.Map<KatastarskaOpstinaConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        /// <summary>
        /// Brisanje katastarske opstine sa trazenim ID-em
        /// </summary>
        /// <param name="katastarskaOpstinaId">Sifra katastarske opstine</param>
        /// <returns></returns>
        /// <response code="200">Vraca izbrisanu katastarsku opstinu</response>
        /// <response code="404">Katastarska opstina nije pronadjena</response>
        /// <response code="500">Doslo je do greske na serveru prilikom brisanja</response>
        [HttpDelete("{katastarskaOpstinaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteKatastarskaOpstina(Guid katastarskaOpstinaId)
        {
            try
            {
                KatastarskaOpstina katastarskaOpstina = katastarskaOpstinaRepository.GetKatastarskaOpstinaById(katastarskaOpstinaId);
                if (katastarskaOpstina == null)
                {
                    return NotFound();
                }
                KatastarskaOpstinaConfirmationDto confirmation = katastarskaOpstinaRepository.DeleteKatastarskaOpstina(katastarskaOpstinaId);
                return Ok(mapper.Map<KatastarskaOpstinaConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Azuriranje postojece katastarske opstine
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca azuriranu katastarsku opstinu</response>
        /// <response code="404">Katastarska opstina nije pronadjena</response>
        /// <response code="500">Doslo je do greske na serveru prilikom azuriranja</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KatastarskaOpstinaConfirmationDto> UpdateKatastarskaOpstina(KatastarskaOpstinaUpdateDto katastarskaOpstinaDto)
        {
            try
            {
                KatastarskaOpstina oldKo = katastarskaOpstinaRepository.GetKatastarskaOpstinaById(katastarskaOpstinaDto.KatastarskaOpstinaId);

                if (oldKo == null)
                {
                    return NotFound();
                }

                KatastarskaOpstina Ko = mapper.Map<KatastarskaOpstina>(katastarskaOpstinaDto);

                mapper.Map(Ko, oldKo);

                KatastarskaOpstinaConfirmationDto confirmation = katastarskaOpstinaRepository.UpdateKatastarskaOpstina(Ko);

                return Ok(mapper.Map<KatastarskaOpstinaConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetKatastarskaOpstinaOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");

            return Ok();
        }
    }
}
