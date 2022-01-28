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
    [Route("api/v1/svojina")]
    [Produces("application/json")]
    public class OblikSvojineController : ControllerBase
    {
        private readonly IOblikSvojineRepository OblikSvojineRepository;
        private readonly IMapper Mapper;

        public OblikSvojineController(IOblikSvojineRepository oblikSvojineRepository, IMapper mapper)
        {
            this.OblikSvojineRepository = oblikSvojineRepository;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Vraca listu svih oblika svojine
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca listu svih oblika svojine</response>
        /// <response code="204">Nema oblika svojine</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<OblikSvojineDto>> GetOblikSvojineList()
        {
            List<OblikSvojine> oblikSvojineList = OblikSvojineRepository.GetOblikSvojineList();

            if (oblikSvojineList == null || oblikSvojineList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<OblikSvojineDto>>(oblikSvojineList));
        }

        /// <summary>
        /// Vraca oblik svojine sa trazenim ID-em
        /// </summary>
        /// <param name="svojinaId">Sifra oblika svojine</param>
        /// <returns></returns>
        /// <response code="200">Vraca trazeni oblik svojine</response>
        /// <response code="404">Oblik svojine nije pronadjen</response>
        [HttpGet("{svojinaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<OblikSvojineDto> GetOblikSvojineById(Guid svojinaId)
        {
            OblikSvojine oblikSvojine = OblikSvojineRepository.GetOblikSvojineById(svojinaId);

            if (oblikSvojine == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<OblikSvojineDto>(oblikSvojine));
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
