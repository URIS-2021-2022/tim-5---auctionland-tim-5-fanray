using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using JavnoNadmetanjeService.Data;
using JavnoNadmetanjeService.Models;
using JavnoNadmetanjeService.Entities;
using AutoMapper;

namespace JavnoNadmetanjeService.Controllers
{
    [ApiController]
    [Route("api/v1/javno-nadmetanje")]
    [Produces("application/json")]
    public class JavnoNadmetanjeController : ControllerBase
    {
        private readonly IJavnoNadmetanjeRepository javnoNadmetanjeRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public JavnoNadmetanjeController(IJavnoNadmetanjeRepository javnoNadmetanjeRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.javnoNadmetanjeRepository = javnoNadmetanjeRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraca listu svih javnih nadmetanja
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca listu svih javnih nadmetanja</response>
        /// <response code="204">Nema javnih nadmetanja</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<JavnoNadmetanjeDto>> GetJavnoNadmetanje()
        {
            List<JavnoNadmetanje> javnaNadmetanja = javnoNadmetanjeRepository.GetJavnoNadmetanjeList();
            if (javnaNadmetanja == null || javnaNadmetanja.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<JavnoNadmetanjeDto>>(javnaNadmetanja));
        }

        /// <summary>
        /// Vraca javno nadmetanje sa trazenim ID-em
        /// </summary>
        /// <param name="parcelaId">Sifra javnog nadmetanja</param>
        /// <returns></returns>
        /// <response code="200">Vraca trazeno javno nadmetanje</response>
        /// <response code="404">Javno nadmetanje nije pronadjeno</response>
        [HttpGet("{javnoNadmetanjeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<JavnoNadmetanje> GetJavnoNadmetanje(Guid javnoNadmetanjeId)
        {
            JavnoNadmetanje javnoNadmetanje = javnoNadmetanjeRepository.GetJavnoNadmetanjeById(javnoNadmetanjeId);
            if (javnoNadmetanje == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<JavnoNadmetanjeDto>(javnoNadmetanje));
        }

        /// <summary>
        /// Upis novog javnog nadmetanja
        /// </summary>
        /// <returns></returns>
        /// <response code="201">Vraca kreirano javno nadmetanje</response>
        /// <response code="500">Doslo je do greske na serveru prilikom kreiranja javnog nadmetanja</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<JavnoNadmetanjeConfirmationDto> CreateJavnoNadmetanje([FromBody] JavnoNadmetanjeCreateDto javnoNadmetanjeDto)
        {
            try
            {
                JavnoNadmetanje javnoNadmetanje = mapper.Map<JavnoNadmetanje>(javnoNadmetanjeDto);
                JavnoNadmetanjeConfirmationDto confirmation = javnoNadmetanjeRepository.CreateJavnoNadmetanje(javnoNadmetanje);
                string location = linkGenerator.GetPathByAction("GetJavnoNadmetanjeById", "JavnoNadmetanje", new { javnoNadmetanjeId = confirmation.JavnoNadmetanjeId });

                return Created(location, mapper.Map<JavnoNadmetanjeConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }

        /// <summary>
        /// Brisanje javnog nadmetanja sa trazenim ID-em
        /// </summary>
        /// <param name="parcelaId">Sifra javnog nadmetanja</param>
        /// <returns></returns>
        /// <response code="200">Vraca izbrisano javno nadmetanje</response>
        /// <response code="404">Javno nadmetanje nije pronadjena</response>
        /// <response code="500">Doslo je do greske na serveru prilikom brisanja javnog nadmetanja</response>
        [HttpDelete("{javnoNadmetanjeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteJavnoNadmetanje(Guid javnoNadmetanjeId)
        {
            try
            {
                JavnoNadmetanje javnoNadmetanje = javnoNadmetanjeRepository.GetJavnoNadmetanjeById(javnoNadmetanjeId);
                if (javnoNadmetanje == null)
                {
                    return NotFound();
                }
                JavnoNadmetanjeConfirmationDto confirmation = javnoNadmetanjeRepository.DeleteJavnoNadmetanje(javnoNadmetanjeId);
                return Ok(mapper.Map<JavnoNadmetanjeConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


    }
}
