using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JavnoNadmetanjeService.Data;
using JavnoNadmetanjeService.Models;
using JavnoNadmetanjeService.Entities;
using Microsoft.AspNetCore.Authorization;

namespace JavnoNadmetanjeService.Controllers
{
    [ApiController]
    [Route("api/v1/sluzbeni-list")]
    [Produces("application/json")]
    public class SluzbeniListController : ControllerBase
    {
        private readonly ISluzbeniListRepository sluzbeniListRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public SluzbeniListController(ISluzbeniListRepository sluzbeniListRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.sluzbeniListRepository = sluzbeniListRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraca listu svih sluzbenih listova
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca listu svih sluzbenih listova</response>
        /// <response code="204">Nema sluzbenih listova</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<SluzbeniListDto>> GetSluzbeniList()
        {
            List<SluzbeniList> sluzbeniListovi = sluzbeniListRepository.GetSluzbeniListList();
            if (sluzbeniListovi == null || sluzbeniListovi.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<SluzbeniListDto>>(sluzbeniListovi));
        }

        /// <summary>
        /// Vraca sluzbeni list sa trazenim ID-em
        /// </summary>
        /// <param name="sluzbeniListId">Sifra sluzbenog lista</param>
        /// <returns></returns>
        /// <response code="200">Vraca trazeni sluzbeni list</response>
        /// <response code="404">Sluzbeni list nije pronadjen</response>
        [HttpGet("{sluzbeniListId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SluzbeniListDto> GetSluzbeniListById(Guid sluzbeniListId)
        {
            SluzbeniList sluzbeniList= sluzbeniListRepository.GetSluzbeniListById(sluzbeniListId);
            if (sluzbeniList == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<SluzbeniListDto>(sluzbeniList));
        }

        /// <summary>
        /// Upis novog sluzbenog lista
        /// </summary>
        /// <returns></returns>
        /// <response code="201">Vraca kreiran sluzbeni list</response>
        /// <response code="500">Doslo je do greske na serveru prilikom kreiranja sluzbenog lista</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<SluzbeniListConfirmationDto> CreateSluzbeniList([FromBody] SluzbeniListCreateDto sluzbeniListDto)
        {
            try
            {
                SluzbeniList sluzbeniList = mapper.Map<SluzbeniList>(sluzbeniListDto);
                SluzbeniListConfirmationDto confirmation = sluzbeniListRepository.CreateSluzbeniList(sluzbeniList);
                string location = linkGenerator.GetPathByAction("GetSluzbeniListById", "SluzbeniList", new { sluzbeniListId = confirmation.SluzbeniListId });

                return Created(location, mapper.Map<SluzbeniListConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        /// <summary>
        /// Brisanje sluzbenog lista sa trazenim ID-em
        /// </summary>
        /// <param name="sluzbeniListId">Sifra sluzbenog lista</param>
        /// <returns></returns>
        /// <response code="200">Vraca izbrisan sluzbeni list</response>
        /// <response code="404">Sluzbeni list nije pronadjen</response>
        /// <response code="500">Doslo je do greske na serveru prilikom brisanja</response>
        [HttpDelete("{sluzbeniListId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteSluzbeniList(Guid sluzbeniListId)
        {
            try
            {
                SluzbeniList sluzbeniList = sluzbeniListRepository.GetSluzbeniListById(sluzbeniListId);
                if (sluzbeniList == null)
                {
                    return NotFound();
                }
                SluzbeniListConfirmationDto confirmation = sluzbeniListRepository.DeleteSluzbeniList(sluzbeniListId);
                return Ok(mapper.Map<SluzbeniListConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Azuriranje postojeceg sluzbenog lista
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca azuriran sluzbeni list</response>
        /// <response code="404">Sluzbeni list nije pronadjen</response>
        /// <response code="500">Doslo je do greske na serveru prilikom azuriranja</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<SluzbeniListConfirmationDto> UpdateSluzbeniList(SluzbeniListUpdateDto sluzbeniListDto)
        {
            try
            {
                SluzbeniList oldSl = sluzbeniListRepository.GetSluzbeniListById(sluzbeniListDto.SluzbeniListId);

                if (oldSl == null)
                {
                    return NotFound();
                }

                SluzbeniList sl = mapper.Map<SluzbeniList>(sluzbeniListDto);

                mapper.Map(sl, oldSl);

                SluzbeniListConfirmationDto confirmation = sluzbeniListRepository.UpdateSluzbeniList(sl);

                return Ok(mapper.Map<SluzbeniListConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetSluzbeniListOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");

            return Ok();
        }
    }
}
