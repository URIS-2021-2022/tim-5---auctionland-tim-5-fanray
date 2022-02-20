using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using LicitacijaService.Data;
using LicitacijaService.Entities;
using LicitacijaService.Models;
using System;
using System.Collections.Generic;
using LicitacijaService.Services;

namespace LicitacijaService.Controllers
{
    [ApiController]
    [Route("api/v1/licitacija")]
    [Produces("application/json")]
    [Authorize]
    public class LicitacijaController : ControllerBase
    {
        private readonly ILicitacijaRepository LicitacijaRepository;
        private readonly LinkGenerator LinkGenerator;
        private readonly IMapper Mapper;
        private readonly ILoggerService LoggerService;

        public LicitacijaController(ILicitacijaRepository licitacijaRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.LicitacijaRepository = licitacijaRepository;
            this.LinkGenerator = linkGenerator;
            this.Mapper = mapper;
            this.LoggerService = loggerService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<LicitacijaDto>> GetLicitacijaList()
        {
            List<Licitacija> licitacijaList = LicitacijaRepository.getLicitacijaList();

            if (licitacijaList == null || licitacijaList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<LicitacijaDto>>(licitacijaList));
        }

        [HttpGet("{licitacijaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Licitacija> GetLicitacijaById(Guid licitacijaId)
        {
            Licitacija licitacija = LicitacijaRepository.getLicitacijaById(licitacijaId);

            if (licitacija == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<LicitacijaDto>(licitacija));
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<LicitacijaConfirmationDto> CreateLicitacija([FromBody] LicitacijaCreateDto licitacijaDto)
        {
            try
            {
              Licitacija licitacija = Mapper.Map<Licitacija>(licitacijaDto);
              LicitacijaConfirmationDto confirmation = LicitacijaRepository.CreateLicitacija(licitacija);

                string location = LinkGenerator.GetPathByAction("GetLicitacijaById", "Licitacija", new { licitacijaId = confirmation.LicitacijaID });

                LoggerService.createLogAsync("Licitacija " + licitacija.LicitacijaID + " je dodata");

                return Created(location, Mapper.Map<LicitacijaConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<LicitacijaConfirmationDto> UpdateLicitacija(LicitacijaUpdateDto licitacijaDto)
        {
            try
            {
                Licitacija oldLicitacija = LicitacijaRepository.getLicitacijaById(licitacijaDto.LicitacijaID);

                if (oldLicitacija == null)
                {
                    return NotFound();
                }

                Licitacija licitacija = Mapper.Map<Licitacija>(licitacijaDto);

                Mapper.Map(licitacija, oldLicitacija);

                LoggerService.createLogAsync("Licitacija " + licitacija.LicitacijaID + " je ažurirana");

                return Ok(Mapper.Map<LicitacijaConfirmationDto>(oldLicitacija));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{licitacijaId}")]
        public ActionResult<LicitacijaConfirmationDto> DeleteParcela(Guid licitacijaId)
        {
            try
            {
                Licitacija licitacija = LicitacijaRepository.getLicitacijaById(licitacijaId);

                if (licitacija == null)
                {
                    return NotFound();
                }

                LicitacijaRepository.DeleteLicitacija(licitacijaId);

                LoggerService.createLogAsync("Licitacija " + licitacija.LicitacijaID + " je izbrisana");

                return Ok(Mapper.Map<LicitacijaConfirmationDto>(licitacija));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Error");
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
