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
    [Route("api/v1/deo-parcele")]
    [Produces("application/json")]
    public class DeoParceleController : ControllerBase
    {
        private readonly IDeoParceleRepository DeoParceleRepository;
        private readonly LinkGenerator LinkGenerator;
        private readonly IMapper Mapper;

        public DeoParceleController(IDeoParceleRepository deoParceleRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.DeoParceleRepository = deoParceleRepository;
            this.LinkGenerator = linkGenerator;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Vraca listu svih delova od trazene parcele
        /// </summary>
        /// <query name="parcelaId"></query>
        /// <returns></returns>
        /// <response code="200">Vraca listu svih delova trazene parcele</response>
        /// <response code="204">Nema delova parcele</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<DeoParceleDto>> GetDeoParceleList([FromQuery(Name = "parcelaId")] Guid parcelaId)
        {
            List<DeoParcele> deoParceleList = DeoParceleRepository.GetDeoParceleList(parcelaId);

            if (deoParceleList == null || deoParceleList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<DeoParceleDto>>(deoParceleList));
        }

        /// <summary>
        /// Vraca deo parcele sa trazenim ID-em
        /// </summary>
        /// <param name="deoParceleId">Sifra dela parcele</param>
        /// <returns></returns>
        /// <response code="200">Vraca trazeni deo parcele</response>
        /// <response code="404">Deo parcele nije pronadjen</response>
        [HttpGet("{deoParceleId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DeoParceleDto> GetDeoParceleById(Guid deoParceleId)
        {
            DeoParcele deoParcele = DeoParceleRepository.GetDeoParcelaById(deoParceleId);

            if (deoParcele == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<DeoParceleDto>(deoParcele));
        }

        /// <summary>
        /// Upis novog dela parcele
        /// </summary>
        /// <returns></returns>
        /// <response code="201">Vraca kreirani deo parcele</response>
        /// <response code="500">Doslo je do greske na serveru prilikom kreiranja dela parcele</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<DeoParceleConfirmationDto> CreateDeoParcele([FromBody] DeoParceleCreateDto deoParceleDto)
        {
            try
            {
                DeoParcele deoParcele = Mapper.Map<DeoParcele>(deoParceleDto);
                DeoParceleConfirmationDto confirmation = DeoParceleRepository.CreateDeoParcele(deoParcele);

                string location = LinkGenerator.GetPathByAction("GetDeoParceleById", "DeoParcele", new { deoParceleId = confirmation.DeoParceleID });

                return Created(location, Mapper.Map<DeoParceleConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Azuriranje postojeceg dela parcele
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca azurirani deo parcele</response>
        /// <response code="404">Deo parcele nije pronadjen</response>
        /// <response code="500">Doslo je do greske na serveru prilikom azuriranja dela parcele</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<DeoParceleConfirmationDto> UpdateDeoParcele(DeoParceleUpdateDto deoParceleDto)
        {
            try
            {
                DeoParcele oldDeoParcele = DeoParceleRepository.GetDeoParcelaById(deoParceleDto.DeoParceleID);

                if (oldDeoParcele == null)
                {
                    return NotFound();
                }

                DeoParcele deoParcele = Mapper.Map<DeoParcele>(deoParceleDto);

                Mapper.Map(deoParcele, oldDeoParcele);

                DeoParceleConfirmationDto confirmation = DeoParceleRepository.UpdateDeoParcele(deoParcele);

                return Ok(Mapper.Map<DeoParceleConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Brisanje dela parcele sa trazenim ID-em
        /// </summary>
        /// <param name="deoParceleId">Sifra dela parcele</param>
        /// <returns></returns>
        /// <response code="200">Vraca izbrisani deo parcele</response>
        /// <response code="404">Deo parcele nije pronadjen</response>
        /// <response code="500">Doslo je do greske na serveru prilikom brisanja dela parcele</response>
        [HttpDelete("{deoParceleId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<DeoParceleConfirmationDto> DeleteDeoParcele(Guid deoParceleId)
        {
            try
            {
                DeoParcele deoParcele = DeoParceleRepository.GetDeoParcelaById(deoParceleId);

                if (deoParcele == null)
                {
                    return NotFound();
                }

                DeoParceleConfirmationDto confirmation = DeoParceleRepository.DeleteDeoParcele(deoParceleId);

                return Ok(Mapper.Map<DeoParceleConfirmationDto>(confirmation));
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
