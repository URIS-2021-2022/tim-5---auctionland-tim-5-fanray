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

namespace LicnostService.Controllers
{
    [ApiController]
    [Route("api/v1/komisija")]
    [Produces("application/json")]
    [Authorize]
    public class KomisijaController : ControllerBase
    {
        private readonly IKomisijaRepository KomisijaRepository;
        private readonly IMapper Mapper;

        public KomisijaController(IKomisijaRepository komisijaRepository, IMapper mapper)
        {
            this.KomisijaRepository = komisijaRepository;
            this.Mapper = mapper;
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

            return Ok(Mapper.Map<KomisijaDto>(komisija));
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
