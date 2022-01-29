using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ParcelaService.Data;
using ParcelaService.Entities;
using ParcelaService.Models;
using System;
using System.Collections.Generic;

namespace ParcelaService.Controllers
{
    [ApiController]
    [Route("api/v1/katastar")]
    [Produces("application/json")]
    [Authorize]
    public class KatastarskaOpstinaController : ControllerBase
    {
        private readonly IKatastarskaOpstinaRepository KatastarskaOpstinaRepository;
        private readonly IMapper Mapper;

        public KatastarskaOpstinaController(IKatastarskaOpstinaRepository katastarskaOpstinaRepository, IMapper mapper)
        {
            this.KatastarskaOpstinaRepository = katastarskaOpstinaRepository;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Vraca listu katastarskih opstina
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca listu svih katastarskih opstina</response>
        /// <response code="204">Nema katastarskih opstina</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<KatastarskaOpstinaDto>> GetKatastarskaOpstinaList()
        {
            List<KatastarskaOpstina> katastarskaOpstinaList = KatastarskaOpstinaRepository.GetKatastarskaOpstinaList();

            if (katastarskaOpstinaList == null || katastarskaOpstinaList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<KatastarskaOpstinaDto>>(katastarskaOpstinaList));
        }

        /// <summary>
        /// Vraca katastarsku opstinu sa trazenim ID-em
        /// </summary>
        /// <param name="katastarId">Sifra katastarske opstine</param>
        /// <returns></returns>
        /// <response code="200">Vraca trazenu katastarsku opstinu</response>
        /// <response code="404">Katastarska opstina nije pronadjena</response>
        [HttpGet("{katastarId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KatastarskaOpstinaDto> GetKatastarskaOpstinaById(Guid katastarId)
        {
            KatastarskaOpstina katastarskaOpstina = KatastarskaOpstinaRepository.GetKatastarskaOpstinaById(katastarId);

            if (katastarskaOpstina == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<KatastarskaOpstinaDto>(katastarskaOpstina));
        }

        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetExamRegistrationOptions()
        {
            Response.Headers.Add("Allow", "GET");

            return Ok();
        }
    }
}
