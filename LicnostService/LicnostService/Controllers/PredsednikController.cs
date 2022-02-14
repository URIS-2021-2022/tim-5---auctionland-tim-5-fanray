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
    [Route("api/v1/predsednik")]
    [Produces("application/json")]
    [Authorize]
    public class PredsednikController : ControllerBase
    {
        private readonly IPredsednikRepository PredsednikRepository;
        private readonly IMapper Mapper;

        public PredsednikController(IPredsednikRepository predsednikRepository, IMapper mapper)
        {
            this.PredsednikRepository = predsednikRepository;
            this.Mapper = mapper;
        }

        /// <response code="204">Nema kultura</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<PredsednikDto>> GetPredsednikList()
        {
            List<Predsednik> predsednikList = PredsednikRepository.GetPredsednikList();

            if (predsednikList == null || predsednikList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<ClanDto>>(predsednikList));
        }

        [HttpGet("{predsednikId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PredsednikDto> GetPredsednikById(Guid predsednikId)
        {
            Predsednik predsednik = PredsednikRepository.GetPredsednikById(predsednikId);

            if (predsednik == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<PredsednikDto>(predsednik));
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
