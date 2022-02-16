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
        private readonly LinkGenerator LinkGenerator;
        private readonly IMapper Mapper;

        public ClanController(IClanRepository clanRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.ClanRepository = clanRepository;
            this.LinkGenerator = linkGenerator;
            this.Mapper = mapper;
        }

       
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<ClanDto>> GetClanList([FromQuery(Name = "licnostId")] Guid licnostId)
        {
            List<Clan> clanList = ClanRepository.GetClanList(licnostId);

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

    
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ClanConfirmationDto> CreateClan([FromBody] ClanCreateDto clanDto)
        {
            try
            {
               Clan clan = Mapper.Map<Clan>(clanDto);
                ClanConfirmationDto confirmation = ClanRepository.CreateClan(clan);

                string location = LinkGenerator.GetPathByAction("GetClanById", "Clan", new { clanId = confirmation.ClanID });

                return Created(location, Mapper.Map<ClanConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ClanConfirmationDto> UpdateClan(ClanUpdateDto clanDto)
        {
            try
            {
                Clan oldClan = ClanRepository.GetClanById(clanDto.ClanID);

                if (oldClan == null)
                {
                    return NotFound();
                }

                Clan clan = Mapper.Map<Clan>(clanDto);

                Mapper.Map(clan, oldClan);

                ClanConfirmationDto confirmation = ClanRepository.UpdateClan(clan);

                return Ok(Mapper.Map<ClanConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        
        [HttpDelete("{clanId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ClanConfirmationDto> DeleteClan(Guid clanId)
        {
            try
            {
                Clan clan = ClanRepository.GetClanById(clanId);

                if (clan == null)
                {
                    return NotFound();
                }

                ClanConfirmationDto confirmation = ClanRepository.DeleteClan(clanId);

                return Ok(Mapper.Map<ClanConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetExamRegistrationOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");

            return Ok();
        }
    }
}
