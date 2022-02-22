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
        private readonly IBrojTableRepository BrojTableRepository;
        private readonly LinkGenerator LinkGenerator;
        private readonly IMapper Mapper;
        private readonly IAdresaService AdresaService;
        private readonly ILoggerService LoggerService;

        public OvlascenoLiceController(
            IOvlascenoLiceRepository ovlascenoLiceRepository, 
            IBrojTableRepository brojTableRepository,
            LinkGenerator linkGenerator,
            IAdresaService adresaService,
            IMapper mapper, ILoggerService 
            loggerService)
        {
            this.OvlascenoLiceRepository = ovlascenoLiceRepository;
            this.BrojTableRepository = brojTableRepository;
            this.LinkGenerator = linkGenerator;
            this.Mapper = mapper;
            this.AdresaService = adresaService;
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

            foreach (OvlascenoLiceService.Entities.OvlascenoLice ol in ovlascenoLiceList)
            {
                ol.BrojTable = BrojTableRepository.GetBrojTableById(ol.BrojTableID);
            }

            List<OvlascenoLiceDto> ovlascenoLiceDto = Mapper.Map<List<OvlascenoLiceDto>>(ovlascenoLiceList);

            foreach (OvlascenoLiceDto olDto in ovlascenoLiceDto)
            {
                olDto.Drzava = AdresaService.GetDrzavaByIdAsync(olDto.DrzavaID, Request).Result;
            }

            LoggerService.createLogAsync("OvlascenoLice", "OvlascenoLice", "GET", 200);

            return Ok(ovlascenoLiceDto);
        }

        [HttpGet("{ovlascenoLiceId}")]
        public ActionResult<OvlascenoLiceService.Entities.OvlascenoLice> GetOvlascenoLiceById(Guid ovlascenoLiceId)
        {
            OvlascenoLiceService.Entities.OvlascenoLice ovlascenoLice = OvlascenoLiceRepository.GetOvlascenoLiceById(ovlascenoLiceId);

            if (ovlascenoLice == null)
            {
                return NotFound();
            }

            ovlascenoLice.BrojTable = BrojTableRepository.GetBrojTableById(ovlascenoLice.BrojTableID);


            OvlascenoLiceDto olDto = Mapper.Map<OvlascenoLiceDto>(ovlascenoLice);

            olDto.Drzava = AdresaService.GetDrzavaByIdAsync(ovlascenoLice.DrzavaID, Request).Result;

            LoggerService.createLogAsync("OvlascenoLice", "OvlascenoLice", "GET", 200);

            return Ok(olDto);
        }

        [HttpPost]
        public ActionResult<OvlascenoLiceConfirmationDto> CreateOvlascenoLice([FromBody] OvlascenoLiceCreateDto ovlascenoLiceDto)
        {
            try
            {
                OvlascenoLiceService.Entities.OvlascenoLice ovlascenoLice = Mapper.Map<OvlascenoLiceService.Entities.OvlascenoLice>(ovlascenoLiceDto);
                OvlascenoLiceConfirmationDto confirmation = OvlascenoLiceRepository.CreateOvlascenoLice(ovlascenoLice);

                string location = LinkGenerator.GetPathByAction("GetOvlascenoLiceById", "OvlascenoLice", new { ovlascenoLiceId = confirmation.OvlascenoLiceID });

                LoggerService.createLogAsync("OvlascenoLice", "OvlascenoLice", "POST", 201);

                return Created(location, Mapper.Map<OvlascenoLiceConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                LoggerService.createLogAsync("OvlascenoLice", "OvlascenoLice", "POST", 500);

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

                LoggerService.createLogAsync("OvlascenoLice", "OvlascenoLice", "PUT", 200);

                return Ok(Mapper.Map<OvlascenoLiceConfirmationDto>(oldOvlascenoLice));
            }
            catch (Exception ex)
            {

                LoggerService.createLogAsync("OvlascenoLice", "OvlascenoLice", "PUT", 500);
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

                LoggerService.createLogAsync("OvlascenoLice", "OvlascenoLice", "DELETE", 200);

                return Ok(Mapper.Map<OvlascenoLiceConfirmationDto>(ovlascenoLice));
            }
            catch (Exception ex)
            {
                LoggerService.createLogAsync("OvlascenoLice", "OvlascenoLice", "DELETE", 500);

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