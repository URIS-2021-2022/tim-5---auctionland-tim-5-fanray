using AutoMapper;
using KupacService.Data;
using KupacService.Entities;
using KupacService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacService.Controllers
{
    [ApiController]
    [Route("api/v1/prioritet")]
    [Produces("application/json")]
    [Authorize]
    public class PrioritetController : ControllerBase
    {
        private readonly IPrioritetRepository PrioritetRepository;
        private readonly IMapper Mapper;

        public PrioritetController(IPrioritetRepository prioritetRepository, IMapper mapper)
        {
            this.PrioritetRepository = prioritetRepository;
            this.Mapper = mapper;
        }
        /// <summary>
        /// Vraca listu svih prioriteta
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca listu svih prioriteta</response>
        /// <response code="204">Nema prioriteta</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<PrioritetDto>> GetPrioritetList()
        {
            List<Prioritet> prioritetList = PrioritetRepository.GetPrioritetList();

            if (prioritetList == null || prioritetList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<PrioritetDto>>(prioritetList));
        }
        /// <summary>
        /// Vraca prioritet sa trazenim ID-em
        /// </summary>
        /// <param name="prioritetId">Sifra prioriteta</param>
        /// <returns></returns>
        /// <response code="200">Vraca trazeni prioritet</response>
        /// <response code="404">Prioritet nije pronadjen</response>
        [HttpGet("{prioritetId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PrioritetDto> GetPrioritetById(Guid prioritetId)
        {
            Prioritet prioritet = PrioritetRepository.GetPrioritetById(prioritetId);

            if (prioritet == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<PrioritetDto>(prioritet));
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
