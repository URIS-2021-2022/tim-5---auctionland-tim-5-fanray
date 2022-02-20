using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using OvlascenoLiceService.Data;
using OvlascenoLiceService.Entities;
using OvlascenoLiceService.Models;
using OvlascenoLiceService.Services;
using System;
using System.Collections.Generic;

namespace OvlascenoLice.Controllers
{
    [ApiController]
    [Route("api/v1/ovlasceno-lice")]
    [Produces("application/json")]
    [Authorize]
    public class OvlascenoLiceController : ControllerBase
    {
        private readonly IOvlascenoLiceRepository OvlascenoLiceRepository;
        private readonly LinkGenerator LinkGenerator;
        private readonly IMapper Mapper;
        private readonly ILoggerService LoggerService;

        public OvlascenoLiceController(IOvlascenoLiceRepository ovlascenoLiceRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
        {
            this.OvlascenoLiceRepository = ovlascenoLiceRepository;
            this.LinkGenerator = linkGenerator;
            this.Mapper = mapper;
            this.LoggerService = loggerService;
        }

        [HttpGet]
        public ActionResult<List<OvlascenoLiceDto>> GetOvlascenoLiceList()
        {
            List<OvlascenoLiceService.Entities.OvlascenoLice> ovlascenoLiceList = OvlascenoLiceRepository.GetOvlascenoLiceList();

            if (ovlascenoLiceList == null || ovlascenoLiceList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<OvlascenoLiceDto>>(ovlascenoLiceList));
        }

        [HttpGet("{ovlascenoLiceId}")]
        public ActionResult<OvlascenoLiceService.Entities.OvlascenoLice> GetOvlascenoLiceById(Guid ovlascenoLiceId)
        {
            OvlascenoLiceService.Entities.OvlascenoLice ovlascenoLice = OvlascenoLiceRepository.GetOvlascenoLiceById(ovlascenoLiceId);

            if (ovlascenoLice == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<OvlascenoLiceDto>(ovlascenoLice));
        }

        [HttpPost]
        public ActionResult<OvlascenoLiceConfirmationDto> CreateOvlascenoLice([FromBody] OvlascenoLiceCreateDto ovlascenoLiceDto)
        {
            try
            {
                OvlascenoLiceService.Entities.OvlascenoLice ovlascenoLice = Mapper.Map<OvlascenoLiceService.Entities.OvlascenoLice>(ovlascenoLiceDto);
                OvlascenoLiceConfirmationDto confirmation = OvlascenoLiceRepository.CreateOvlascenoLice(ovlascenoLice);

                string location = LinkGenerator.GetPathByAction("GetOvlascenoLiceById", "OvlascenoLice", new { ovlascenoLiceId = confirmation.OvlascenoLiceID });

                LoggerService.createLogAsync("Ovlašćeno lice " +  ovlascenoLice.OvlascenoLiceID + " je dodato");

                return Created(location, Mapper.Map<OvlascenoLiceConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<OvlascenoLiceConfirmationDto> UpdateOvlascenoLice(OvlascenoLiceUpdateDto ovlascenoLiceDto)
        {
            try
            {
                OvlascenoLiceService.Entities.OvlascenoLice oldOvlascenoLice = OvlascenoLiceRepository.GetOvlascenoLiceById(ovlascenoLiceDto.OvlascenoLiceID);

                if (oldOvlascenoLice == null)
                {
                    return NotFound();
                }

                OvlascenoLiceService.Entities.OvlascenoLice ovlascenoLice = Mapper.Map<OvlascenoLiceService.Entities.OvlascenoLice>(ovlascenoLiceDto);

                Mapper.Map(ovlascenoLice, oldOvlascenoLice);

                LoggerService.createLogAsync("Ovlašćeno lice " + ovlascenoLice.OvlascenoLiceID + " je ažurirano");

                return Ok(Mapper.Map<OvlascenoLiceConfirmationDto>(oldOvlascenoLice));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{ovlascenoLiceId}")]
        public ActionResult<OvlascenoLiceConfirmationDto> DeleteOvlascenoLice(Guid ovlascenoLiceId)
        {
            try
            {
                OvlascenoLiceService.Entities.OvlascenoLice ovlascenoLice = OvlascenoLiceRepository.GetOvlascenoLiceById(ovlascenoLiceId);

                if (ovlascenoLice == null)
                {
                    return NotFound();
                }

                OvlascenoLiceRepository.DeleteOvlascenoLice(ovlascenoLiceId);

                LoggerService.createLogAsync("Ovlašćeno lice " + ovlascenoLice.OvlascenoLiceID + " je izbrisano");

                return Ok(Mapper.Map<OvlascenoLiceConfirmationDto>(ovlascenoLice));
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