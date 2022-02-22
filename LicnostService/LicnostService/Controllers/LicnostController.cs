using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using LicnostService.Data;
using LicnostService.Entities;
using LicnostService.Models;
using System;
using System.Collections.Generic;
using LicnostService.Services;

namespace LicnostService.Controllers
{
    [ApiController]
    [Route("api/v1/licnost")]
    [Produces("application/json")]
    [Authorize]
    public class LicnostController : ControllerBase
    {
        private readonly ILicnostRepository LicnostRepository;
        private readonly LinkGenerator LinkGenerator;
        private readonly IMapper Mapper;
        private readonly ILoggerService LoggerService;

        public LicnostController(ILicnostRepository licnostRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.LicnostRepository = licnostRepository;
            this.LinkGenerator = linkGenerator;
            this.Mapper = mapper;
            this.LoggerService = loggerService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<LicnostDto>> GetLicnostList()
        {
            List<Licnost> licnostList = LicnostRepository.GetLicnostList();

            if (licnostList == null || licnostList.Count == 0)
            {
                return NoContent();
            }

            LoggerService.createLogAsync("Licnost", "Licnost", "GET", 200);

            return Ok(Mapper.Map<List<LicnostDto>>(licnostList));
        }

        [HttpGet("{licnostId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<LicnostDto> GetLicnostById(Guid licnostId)
        {
            Licnost licnost = LicnostRepository.GetLicnostById(licnostId);

            if (licnost == null)
            {
                return NotFound();
            }

            LoggerService.createLogAsync("Licnost", "Licnost", "GET", 200);

            return Ok(Mapper.Map<LicnostDto>(licnost));
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<LicnostConfirmationDto> CreateLicnost([FromBody] LicnostCreateDto licnostDto)
        {
            try
            {
                Licnost licnost = Mapper.Map<Licnost>(licnostDto);
                LicnostConfirmationDto confirmation = LicnostRepository.CreateLicnost(licnost);

                string location = LinkGenerator.GetPathByAction("GetLicnostById", "Licnost", new { licnostId = confirmation.LicnostID });

                LoggerService.createLogAsync("Licnost", "Licnost", "POST", 201);

                return Created(location, Mapper.Map<LicnostConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                LoggerService.createLogAsync("Licnost", "Komisija", "POST", 500);

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<LicnostConfirmationDto> UpdateLicnost(LicnostUpdateDto licnostDto)
        {
            try
            {
                Licnost oldLicnost = LicnostRepository.GetLicnostById(licnostDto.LicnostID);

                if (oldLicnost == null)
                {
                    return NotFound();
                }

                Licnost licnost = Mapper.Map<Licnost>(licnostDto);

                Mapper.Map(licnost, oldLicnost);

                LicnostConfirmationDto confirmation = LicnostRepository.UpdateLicnost(licnost);

                LoggerService.createLogAsync("Licnost", "Licnost", "PUT", 200);

                return Ok(Mapper.Map<LicnostConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                LoggerService.createLogAsync("Licnost", "Licnost", "PUT", 500);

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{licnostId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<LicnostConfirmationDto> DeleteLicnost(Guid licnostId)
        {
            try
            {
                Licnost licnost = LicnostRepository.GetLicnostById(licnostId);

                if (licnost == null)
                {
                    return NotFound();
                }

                LicnostConfirmationDto confirmation = LicnostRepository.DeleteLicnost(licnostId);

                LoggerService.createLogAsync("Licnost", "Licnost", "DELETE", 200);

                return Ok(Mapper.Map<LicnostConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                LoggerService.createLogAsync("Licnost", "Licnost", "DELETE", 500);

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
