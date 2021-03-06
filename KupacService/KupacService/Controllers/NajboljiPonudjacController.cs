using AutoMapper;
using KupacService.Data;
using KupacService.Entities;
using KupacService.Models;
using KupacService.Services;
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
    [Route("api/v1/najbolji-ponudjac")]
    [Produces("application/json")]
    [Authorize]
    public class NajboljiPonudjacController : ControllerBase
    {
        private readonly INajboljiPonudjacRepository NajboljiPonudjacRepository;
        private readonly LinkGenerator LinkGenerator;
        private readonly IMapper Mapper;
        private readonly ILoggerService LoggerService;

        public NajboljiPonudjacController(
            INajboljiPonudjacRepository najboljiPonudjacRepository, 
            LinkGenerator linkGenerator, 
            IMapper mapper, 
            ILoggerService loggerService)
        {
            this.NajboljiPonudjacRepository = najboljiPonudjacRepository;
            this.LinkGenerator = linkGenerator;
            this.Mapper = mapper;
            this.LoggerService = loggerService;
        }
        /// <summary>
        /// Vraca listu svih najboljih ponudjaca
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca listu svih najboljih ponudjaca</response>
        /// <response code="204">Nema najboljih ponudjaca</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<NajboljiPonudjacDto>> GetNajboljiPonudjacList()
        {
            List<NajboljiPonudjac> najboljiPonudjacList = NajboljiPonudjacRepository.GetNajbolji_PonudjacList();

            if (najboljiPonudjacList == null || najboljiPonudjacList.Count == 0)
            {
                return NoContent();
            }

            LoggerService.createLogAsync("Kupac", "NajboljiPonudjac", "GET", 200);

            return Ok(Mapper.Map<List<NajboljiPonudjacDto>>(najboljiPonudjacList));
        }

        /// <summary>
        /// Vraca najboljeg ponudjaca sa trazenim ID-em
        /// </summary>
        /// <param name="najboljiPonudjacId">Sifra najboljeg ponudjaca</param>
        /// <returns></returns>
        /// <response code="200">Vraca najboljeg ponudjaca</response>
        /// <response code="404">Najbolji ponudjac nije pronadjen</response>
        [HttpGet("{najboljiPonudjacId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<NajboljiPonudjacDto> GetNajbolji_PonudjacById(Guid najboljiPonudjacId)
        {
            NajboljiPonudjac najboljiPonudjac = NajboljiPonudjacRepository.GetNajbolji_PonudjacById(najboljiPonudjacId);

            if (najboljiPonudjac == null)
            {
                return NotFound();
            }

            LoggerService.createLogAsync("Kupac", "NajboljiPonudjac", "GET", 200);

            return Ok(Mapper.Map<NajboljiPonudjacDto>(najboljiPonudjac));
        }

        /// <summary>
        /// Upis novog najboljeg ponudjaca
        /// </summary>
        /// <returns></returns>
        /// <response code="201">Vraca kreiranog ponudjaca</response>
        /// <response code="500">Doslo je do greske na serveru prilikom kreiranja ponudjaca</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<NajboljiPonudjacConfirmationDto> CreateNajboljiPonudjac([FromBody] NajboljiPonudjacCreateDto najboljiPonudjacDto)
        {
            try
            {
                NajboljiPonudjac najboljiPonudjac = Mapper.Map<NajboljiPonudjac>(najboljiPonudjacDto);
                NajboljiPonudjacConfirmationDto confirmation = NajboljiPonudjacRepository.CreateNajboljiPonudjac(najboljiPonudjac);

                string location = LinkGenerator.GetPathByAction("GetNajbolji_PonudjacById", "NajboljiPonudjac", new { najboljiPonudjacId = confirmation.NajboljiPonudjacId });

                LoggerService.createLogAsync("Kupac", "NajboljiPonudjac", "POST", 201);

                return Created(location, Mapper.Map<NajboljiPonudjacConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {

                LoggerService.createLogAsync("Kupac", "NajboljiPonudjac", "POST", 500);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        /// <summary>
        /// Azuriranje postojeceg najboljeg ponudjaca
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca azuriranog najboljeg ponudjaca</response>
        /// <response code="404">Najbolji ponudjac nije pronadjen </response>
        /// <response code="500">Doslo je do greske na serveru prilikom azuriranja najboljeg ponudjaca</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<NajboljiPonudjacConfirmationDto> UpdateNajboljiPonudjac(NajboljiPonudjacUpdateDto najboljiPonudjacDto)
        {
            try
            {
                NajboljiPonudjac oldnajboljiPonudjac = NajboljiPonudjacRepository.GetNajbolji_PonudjacById(najboljiPonudjacDto.NajboljiPonudjacId);

                if (oldnajboljiPonudjac == null)
                {
                    return NotFound();
                }

                NajboljiPonudjac najboljiPonudjac = Mapper.Map<NajboljiPonudjac>(najboljiPonudjacDto);

                Mapper.Map(najboljiPonudjac, oldnajboljiPonudjac);

                NajboljiPonudjacConfirmationDto confirmation = NajboljiPonudjacRepository.UpdateNajboljiPonudjac(najboljiPonudjac);

                LoggerService.createLogAsync("Kupac", "NajboljiPonudjac", "PUT", 200);

                return Ok(Mapper.Map<NajboljiPonudjacConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                LoggerService.createLogAsync("Kupac", "NajboljiPonudjac", "PUT", 500);

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Brisanje najboljeg ponudjaca sa trazenim ID-em
        /// </summary>
        /// <param name="najboljiPonudjacId">Sifra najboljeg ponudjaca</param>
        /// <returns></returns>
        /// <response code="200">Vraca izbrisanog ponudjaca</response>
        /// <response code="404">Ponudjac nije pronadjen</response>
        /// <response code="500">Doslo je do greske na serveru prilikom brisanja ponudjaca</response>
        [HttpDelete("{najboljiPonudjacId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<NajboljiPonudjacConfirmationDto> DeleteNajboljiPonudjac(Guid najboljiPonudjacId)
        {
            try
            {
                NajboljiPonudjac najboljiPonudjac = NajboljiPonudjacRepository.GetNajbolji_PonudjacById(najboljiPonudjacId);

                if (najboljiPonudjac == null)
                {
                    return NotFound();
                }

                NajboljiPonudjacConfirmationDto confirmation = NajboljiPonudjacRepository.DeleteNajboljiPonudjac(najboljiPonudjacId);

                LoggerService.createLogAsync("Kupac", "NajboljiPonudjac", "DELETE", 200);

                return Ok(Mapper.Map<NajboljiPonudjacConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                LoggerService.createLogAsync("Kupac", "NajboljiPonudjac", "DELETE", 500);

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
