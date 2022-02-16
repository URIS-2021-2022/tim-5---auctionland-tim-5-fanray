﻿using AutoMapper;
using KupacService.Data;
using KupacService.Entities;
using KupacService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacService.Controllers
{
    [ApiController]
    [Route("api/v1/kupac")]
    [Produces("application/json")]
    [Authorize]
    public class KupacController : ControllerBase
    {
        private readonly IKupacRepository KupacRepository;
        private readonly LinkGenerator LinkGenerator;
        private readonly IMapper Mapper;

        public KupacController(IKupacRepository kupacRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.KupacRepository = kupacRepository;
            this.LinkGenerator = linkGenerator;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Vraca listu svih kupaca
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca listu svih kupaca</response>
        /// <response code="204">Nema kupca</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<KupacDto>> GetKupacList()
        {
            List<Kupac> kupacList = KupacRepository.GetKupacList();

            if (kupacList == null || kupacList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<KupacDto>>(kupacList));
        }

        /// <summary>
        /// Vraca kupca sa trazenim ID-em
        /// </summary>
        /// <param name="kupacId">Sifra kupca</param>
        /// <returns></returns>
        /// <response code="200">Vraca trazenog kupca</response>
        /// <response code="404">Kupac nije pronadjen</response>
        [HttpGet("{kupacId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KupacDto> GetKupacById(Guid kupacId)
        {
            Kupac kupac = KupacRepository.GetKupacById(kupacId);

            if (kupac == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<KupacDto>(kupac));
        }
        //...

        /// <summary>
        /// Upis novog kupca
        /// </summary>
        /// <returns></returns>
        /// <response code="201">Vraca kreiranog kupca</response>
        /// <response code="500">Doslo je do greske na serveru prilikom kreiranja kupca</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KupacConfirmationDto> CreateKupac([FromBody] KupacCreateDto kupacDto)
        {
            try
            {
                Kupac kupac = Mapper.Map<Kupac>(kupacDto);
                KupacConfirmationDto confirmation = KupacRepository.CreateKupac(kupac);

                string location = LinkGenerator.GetPathByAction("GetKupacById", "Kupac", new { kupacId = confirmation.KupacId });

                return Created(location, Mapper.Map<KupacConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// Azuriranje postojeceg kupca
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca azuriranog kupca</response>
        /// <response code="404">Kupac nije pronadjen </response>
        /// <response code="500">Doslo je do greske na serveru prilikom azuriranja kupca</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KupacConfirmationDto> UpdateKupac(KupacUpdateDto kupacDto)
        {
            try
            {
                Kupac oldKupac = KupacRepository.GetKupacById(kupacDto.KupacId);

                if (oldKupac == null)
                {
                    return NotFound();
                }

                Kupac kupac = Mapper.Map<Kupac>(kupacDto);

                Mapper.Map(kupac, oldKupac);

                KupacConfirmationDto confirmation = KupacRepository.UpdateKupac(kupac);

                return Ok(Mapper.Map<KupacConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Brisanje kupca sa trazenim ID-em
        /// </summary>
        /// <param name="kupacId">Sifra kupca</param>
        /// <returns></returns>
        /// <response code="200">Vraca izbrisanog kupca</response>
        /// <response code="404">Kupac nije pronadjen</response>
        /// <response code="500">Doslo je do greske na serveru prilikom brisanja kupca</response>
        [HttpDelete("{kupacId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KupacConfirmationDto> DeleteKupac(Guid kupacId)
        {
            try
            {
                Kupac kupac = KupacRepository.GetKupacById(kupacId);

                if (kupac == null)
                {
                    return NotFound();
                }

                KupacConfirmationDto confirmation = KupacRepository.DeleteKupac(kupacId);

                return Ok(Mapper.Map<KupacConfirmationDto>(confirmation));
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