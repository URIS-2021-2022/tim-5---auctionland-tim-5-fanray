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
    [Route("api/v1/clan")]
    [Produces("application/json")]
    [Authorize]
    public class ClanController : ControllerBase
    {
        private readonly IClanRepository ClanRepository;
        private readonly IMapper Mapper;

        public ClanController(IClanRepository kulturaRepository, IMapper mapper)
        {
            this.ClanRepository = kulturaRepository;
            this.Mapper = mapper;
        }

        /// <response code="204">Nema kultura</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<ClanDto>> GetClanList()
        {
            List<Clan> clanList = ClanRepository.GetClanList();

            if (clanList == null || clanList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<ClanDto>>(clanList));
        }

        [HttpGet("{clanId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ClanDto> GetClanById(Guid clanId)
        {
            Clan clan = ClanRepository.GetClanById(clanId);

            if (clan == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<ClanDto>(clan));
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
