using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using OvlascenoLiceService.Data;
using OvlascenoLiceService.Entities;
using OvlascenoLiceService.Models;
using System;
using System.Collections.Generic;

namespace OvlascenoLice.Controllers
{
    [ApiController]
    [Route("api/v1/lice")]
    public class OvlascenoLiceController : ControllerBase
    {
        private IOvlascenoLiceRepository OvlascenoLiceRepository;
        private readonly LinkGenerator LinkGenerator;
        private readonly IMapper Mapper;

        public OvlascenoLiceController(IOvlascenoLiceRepository ovlascenoLiceRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.OvlascenoLiceRepository = ovlascenoLiceRepository;
            this.LinkGenerator = linkGenerator;
            this.Mapper = mapper;
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

        [HttpGet("{liceId}")]
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

                return Created(location, Mapper.Map<OvlascenoLiceConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Error");
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

                return Ok(Mapper.Map<OvlascenoLiceConfirmationDto>(oldOvlascenoLice));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update Error");
            }
        }

        [HttpDelete("{liceId}")]
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

                return Ok(Mapper.Map<OvlascenoLiceConfirmationDto>(ovlascenoLice));
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