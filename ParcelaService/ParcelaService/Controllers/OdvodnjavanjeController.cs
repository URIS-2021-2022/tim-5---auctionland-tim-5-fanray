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
    [Route("api/v1/odvodnjavanje")]
    [Produces("application/json")]
    public class OdvodnjavanjeController : ControllerBase
    {
        private readonly IOdvodnjavanjeRepository OdvodnjavanjeRepository;
        private readonly IMapper Mapper;

        public OdvodnjavanjeController(IOdvodnjavanjeRepository odvodnjavanjeRepository, IMapper mapper)
        {
            this.OdvodnjavanjeRepository = odvodnjavanjeRepository;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Vraca listu svih odvodnjavanja
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca listu svih odvodnjavanja</response>
        /// <response code="204">Nema odvodnjavanja</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<OdvodnjavanjeDto>> GetOdvodnjavanjeList()
        {
            List<Odvodnjavanje> odvodnjavanjeList = OdvodnjavanjeRepository.GetOdvodnjavanjeList();

            if (odvodnjavanjeList == null || odvodnjavanjeList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<OdvodnjavanjeDto>>(odvodnjavanjeList));
        }

        /// <summary>
        /// Vraca odvodnjavanje sa trazenim ID-em
        /// </summary>
        /// <param name="odvodnjavanjeId">Sifra odvodnjavanja</param>
        /// <returns></returns>
        /// <response code="200">Vraca trazeno odvodnjavanje</response>
        /// <response code="404">Odvodnjavanje nije pronadjeno</response>
        [HttpGet("{odvodnjavanjeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<OdvodnjavanjeDto> GetOdvodnjavanjeById(Guid odvodnjavanjeId)
        {
            Odvodnjavanje odvodnjavanje = OdvodnjavanjeRepository.GetOdvodnjavanjeById(odvodnjavanjeId);

            if (odvodnjavanje == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<OdvodnjavanjeDto>(odvodnjavanje));
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
