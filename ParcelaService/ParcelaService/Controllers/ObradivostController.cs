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
    [Route("api/v1/obradivost")]
    [Produces("application/json")]
    public class ObradivostController : ControllerBase
    {
        private readonly IObradivostRepository ObradivostRepository;
        private readonly IMapper Mapper;

        public ObradivostController(IObradivostRepository obradivostRepository, IMapper mapper)
        {
            this.ObradivostRepository = obradivostRepository;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Vraca listu svih obradivosti
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca listu svih obradivosti</response>
        /// <response code="204">Nema obradivosti</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<ObradivostDto>> GetObradivostList()
        {
            List<Obradivost> obradivostList = ObradivostRepository.GetObradivostList();

            if (obradivostList == null || obradivostList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<ObradivostDto>>(obradivostList));
        }

        /// <summary>
        /// Vraca obradivost sa trazenim ID-em
        /// </summary>
        /// <param name="obradivostId">Sifra obradivosti</param>
        /// <returns></returns>
        /// <response code="200">Vraca trazenu obradivost</response>
        /// <response code="404">Obradivost nije pronadjeno</response>
        [HttpGet("{obradivostId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ObradivostDto> GetObradivostById(Guid obradivostId)
        {
            Obradivost obradivost = ObradivostRepository.GetObradivostById(obradivostId);

            if (obradivost == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<ObradivostDto>(obradivost));
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
