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
    [Route("api/v1/predsednik")]
    [Produces("application/json")]
    [Authorize]
    public class PredsednikController : ControllerBase
    {
        private readonly IPredsednikRepository PredsednikRepository;
        private readonly LinkGenerator LinkGenerator;
        private readonly IMapper Mapper;
        private readonly ILoggerService LoggerService;

        public PredsednikController(IPredsednikRepository predsednikRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.PredsednikRepository = predsednikRepository;
            this.LinkGenerator = linkGenerator;
            this.Mapper = mapper;
            this.LoggerService = loggerService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<PredsednikDto>> GetPredsednikList([FromQuery(Name = "licnostId")] Guid licnostId)
        {
            List<Predsednik> predsednikList = PredsednikRepository.GetPredsednikList(licnostId);

            if (predsednikList == null || predsednikList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<PredsednikDto>>(predsednikList));
        }


        [HttpGet("{predsednikId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PredsednikDto> GetPredsednikById(Guid predsednikId)
        {
            Predsednik predsednik = PredsednikRepository.GetPredsednikById(predsednikId);

            if (predsednik == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<PredsednikDto>(predsednik));
        }


        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PredsednikConfirmationDto> CreatePredsednik([FromBody] PredsednikCreateDto predsednikDto)
        {
            try
            {
                Predsednik predsednik = Mapper.Map<Predsednik>(predsednikDto);
                PredsednikConfirmationDto confirmation = PredsednikRepository.CreatePredsednik(predsednik);

                string location = LinkGenerator.GetPathByAction("GetPredsednikById", "Predsednik", new { predsednikId = confirmation.PredsednikID });

                LoggerService.createLogAsync("Predsednik " + predsednik.PredsednikID + " je dodat");

                return Created(location, Mapper.Map<PredsednikConfirmationDto>(confirmation));
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
        public ActionResult<PredsednikConfirmationDto> UpdatePredsednik(PredsednikUpdateDto predsednikDto)
        {
            try
            {
                Predsednik oldPredsednik = PredsednikRepository.GetPredsednikById(predsednikDto.PredsednikID);

                if (oldPredsednik == null)
                {
                    return NotFound();
                }

               Predsednik predsednik = Mapper.Map<Predsednik>(predsednikDto);

                Mapper.Map(predsednik, oldPredsednik);

                PredsednikConfirmationDto confirmation = PredsednikRepository.UpdatePredsednik(predsednik);

                LoggerService.createLogAsync("Predsednik " + predsednik.PredsednikID + " je ažuriran");

                return Ok(Mapper.Map<PredsednikConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpDelete("{predsednikId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PredsednikConfirmationDto> DeletePredsednik(Guid predsednikId)
        {
            try
            {
                Predsednik predsednik = PredsednikRepository.GetPredsednikById(predsednikId);

                if (predsednik == null)
                {
                    return NotFound();
                }

                PredsednikConfirmationDto confirmation = PredsednikRepository.DeletePredsednik(predsednikId);

                LoggerService.createLogAsync("Predsednik " + predsednik.PredsednikID + " je izbrisan");

                return Ok(Mapper.Map<PredsednikConfirmationDto>(confirmation));
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
