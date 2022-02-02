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
    [Route("api/v1/klasa")]
    [Produces("application/json")]
    [Authorize]
    public class KlasaController : ControllerBase
    {
        private readonly IKlasaRepository KlasaRepository;
        private readonly IMapper Mapper;

        public KlasaController(IKlasaRepository klasaRepository, IMapper mapper)
        {
            this.KlasaRepository = klasaRepository;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Vraca listu klasa
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca listu svih klasa</response>
        /// <response code="204">Nema klasa</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<KlasaDto>> GetKlasaList()
        {
            List<Klasa> klasaList = KlasaRepository.GetKlasaList();

            if (klasaList == null || klasaList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<KlasaDto>>(klasaList));
        }

        /// <summary>
        /// Vraca klasu sa trazenim ID-em
        /// </summary>
        /// <param name="klasaId">Sifra klase</param>
        /// <returns></returns>
        /// <response code="200">Vraca trazenu klasu</response>
        /// <response code="404">Klasa nije pronadjena</response>
        [HttpGet("{klasaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KlasaDto> GetKlasaById(Guid klasaId)
        {
            Klasa klasa = KlasaRepository.GetKlasaById(klasaId);

            if (klasa == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<KlasaDto>(klasa));
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
