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
    [Route("api/v1/kultura")]
    [Produces("application/json")]
    [Authorize]
    public class KulturaController : ControllerBase
    {
        private readonly IKulturaRepository KulturaRepository;
        private readonly IMapper Mapper;

        public KulturaController(IKulturaRepository kulturaRepository, IMapper mapper)
        {
            this.KulturaRepository = kulturaRepository;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Vraca listu svih kultura
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca listu svih kultura</response>
        /// <response code="204">Nema kultura</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<KulturaDto>> GetKulturaList()
        {
            List<Kultura> kulturaList = KulturaRepository.GetKulturaList();

            if (kulturaList == null || kulturaList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<KulturaDto>>(kulturaList));
        }

        /// <summary>
        /// Vraca kulturu sa trazenim ID-em
        /// </summary>
        /// <param name="kulturaId">Sifra kulture</param>
        /// <returns></returns>
        /// <response code="200">Vraca trazenu kulturu</response>
        /// <response code="404">Kultura nije pronadjena</response>
        [HttpGet("{kulturaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KulturaDto> GetKulturaById(Guid kulturaId)
        {
            Kultura kultura = KulturaRepository.GetKulturaById(kulturaId);

            if (kultura == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<KulturaDto>(kultura));
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
