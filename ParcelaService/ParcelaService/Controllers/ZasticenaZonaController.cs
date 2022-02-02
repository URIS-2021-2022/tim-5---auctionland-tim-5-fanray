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
    [Route("api/v1/zona")]
    [Produces("application/json")]
    [Authorize]
    public class ZasticenaZonaController : ControllerBase
    {
        private readonly IZasticenaZonaRepository ZasticenaZonaRepository;
        private readonly IMapper Mapper;

        public ZasticenaZonaController(IZasticenaZonaRepository zasticenaZonaRepository, IMapper mapper)
        {
            this.ZasticenaZonaRepository = zasticenaZonaRepository;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Vraca listu svih zasticenih zona
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca listu svih zasticenih zona</response>
        /// <response code="204">Nema zasticenih zona</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<ZasticenaZonaDto>> GetZasticenaZonaList()
        {
            List<ZasticenaZona> zasticenaZonaList = ZasticenaZonaRepository.GetZasticenaZonaList();

            if (zasticenaZonaList == null || zasticenaZonaList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<ZasticenaZonaDto>>(zasticenaZonaList));
        }

        /// <summary>
        /// Vraca zasticenu zonu sa trazenim ID-em
        /// </summary>
        /// <param name="zonaId">Sifra zasticene zone</param>
        /// <returns></returns>
        /// <response code="200">Vraca trazenu zasticenu zonu</response>
        /// <response code="404">Zasticena zona nije pronadjena</response>
        [HttpGet("{zonaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ZasticenaZonaDto> GetZasticenaZonaById(Guid zonaId)
        {
            ZasticenaZona zasticenaZona = ZasticenaZonaRepository.GetZasticenaZonaById(zonaId);

            if (zasticenaZona == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<ZasticenaZonaDto>(zasticenaZona));
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
