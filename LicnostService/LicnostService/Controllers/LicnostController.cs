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

        public LicnostController(ILicnostRepository licnostRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.LicnostRepository = licnostRepository;
            this.LinkGenerator = linkGenerator;
            this.Mapper = mapper;
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

                return Created(location, Mapper.Map<LicnostConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
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

                return Ok(Mapper.Map<LicnostConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
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

                return Ok(Mapper.Map<LicnostConfirmationDto>(confirmation));
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
