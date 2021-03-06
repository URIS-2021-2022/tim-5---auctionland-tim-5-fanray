using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ZalbaService.Data;
using ZalbaService.Entities;
using ZalbaService.Models;
using System;
using System.Collections.Generic;
using ZalbaService.Services;

namespace ZalbaService.Controllers
{
    [ApiController]
    [Route("api/v1/zalba")]
    [Produces("application/json")]
    [Authorize]
    public class ZalbaController : ControllerBase
    {
        private readonly IZalbaRepository ZalbaRepository;
        private readonly IRadnjaNaOsnovuZalbeRepository RadnjaNaOsnovuZalbeRepository;
        private readonly IStatusZalbeRepository StatusZalbeRepository;
        private readonly ITipZalbeRepository TipZalbeRepository;
        private readonly LinkGenerator LinkGenerator;
        private readonly IMapper Mapper;
        private readonly ILoggerService LoggerService;
        
        public ZalbaController(
            IZalbaRepository zalbaRepository, 
            IRadnjaNaOsnovuZalbeRepository radnjaNaOsnovuZalbeRepository,
            IStatusZalbeRepository statusZalbeRepository,
            ITipZalbeRepository tipZalbeRepository,
            LinkGenerator linkGenerator, 
            IMapper mapper, 
            ILoggerService loggerService)
        {
            this.ZalbaRepository = zalbaRepository;
            this.RadnjaNaOsnovuZalbeRepository = radnjaNaOsnovuZalbeRepository;
            this.StatusZalbeRepository = statusZalbeRepository;
            this.TipZalbeRepository = tipZalbeRepository;
            this.LinkGenerator = linkGenerator;
            this.Mapper = mapper;
            this.LoggerService = loggerService;
        }
        
        [HttpGet]
        public ActionResult<List<ZalbaDto>> GetZalbaList()
        {
            List<Zalba> zalbaList = ZalbaRepository.GetZalbaList();

            if (zalbaList == null || zalbaList.Count == 0)
            {
                return NoContent();
            }

            foreach (Zalba z in zalbaList)
            {
                z.RadnjaNaOsnovuZalbe = RadnjaNaOsnovuZalbeRepository.GetRadnjaNaOsnovuZalbeById(z.RadnjaNaOsnovuZalbeID);
                z.StatusZalbe = StatusZalbeRepository.GetStatusZalbeById(z.StatusZalbeID);
                z.TipZalbe = TipZalbeRepository.GetTipZalbeById(z.TipZalbeID);
            }

            LoggerService.createLogAsync("Zalba", "Zalba", "GET", 200);

            return Ok(Mapper.Map<List<ZalbaDto>>(zalbaList));
        }
        
        [HttpGet("{zalbaId}")]
        public ActionResult<Zalba> GetZalbaById(Guid zalbaId)
        {
            Zalba zalba = ZalbaRepository.GetZalbaById(zalbaId);

            if (zalba == null)
            {
                return NotFound();
            }

            zalba.RadnjaNaOsnovuZalbe = RadnjaNaOsnovuZalbeRepository.GetRadnjaNaOsnovuZalbeById(zalba.RadnjaNaOsnovuZalbeID);
            zalba.StatusZalbe = StatusZalbeRepository.GetStatusZalbeById(zalba.StatusZalbeID);
            zalba.TipZalbe = TipZalbeRepository.GetTipZalbeById(zalba.TipZalbeID);

            LoggerService.createLogAsync("Zalba", "Zalba", "GET", 200);

            return Ok(Mapper.Map<ZalbaDto>(zalba));
        }

        [HttpPost]
        public ActionResult<ZalbaConfirmationDto> CreateZalba([FromBody] ZalbaCreateDto zalbaDto)
        {
            try
            {
                Zalba zalba = Mapper.Map<Zalba>(zalbaDto);
                ZalbaConfirmationDto confirmation = ZalbaRepository.CreateZalba(zalba);

                string location = LinkGenerator.GetPathByAction("GetZalbaById", "Zalba", new { zalbaId = confirmation.ZalbaID });

                LoggerService.createLogAsync("Zalba", "Zalba", "POST", 201);

                return Created(location, Mapper.Map<ZalbaConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                LoggerService.createLogAsync("Zalba", "Zalba", "POST", 500);

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<ZalbaConfirmationDto> UpdateZalba(ZalbaUpdateDto zalbaDto)
        {
            try
            {
                Zalba oldZalba = ZalbaRepository.GetZalbaById(zalbaDto.ZalbaID);

                if (oldZalba == null)
                {
                    return NotFound();
                }

                Zalba zalba = Mapper.Map<Zalba>(zalbaDto);

                Mapper.Map(zalba, oldZalba);

                LoggerService.createLogAsync("Zalba", "Zalba", "PUT", 200);

                return Ok(Mapper.Map<ZalbaConfirmationDto>(oldZalba));
            }
            catch (Exception ex)
            {
                LoggerService.createLogAsync("Zalba", "Zalba", "PUT", 500);

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{zalbaId}")]
        public ActionResult<ZalbaConfirmationDto> DeleteZalba(Guid zalbaId)
        {
            try
            {
                Zalba zalba = ZalbaRepository.GetZalbaById(zalbaId);

                if (zalba == null)
                {
                    return NotFound();
                }

                ZalbaRepository.DeleteZalba(zalbaId);

                LoggerService.createLogAsync("Zalba", "Zalba", "DELETE", 200);

                return Ok(Mapper.Map<ZalbaConfirmationDto>(zalba));
            }
            catch (Exception ex)
            {
                LoggerService.createLogAsync("Zalba", "Zalba", "DELETE", 500);

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