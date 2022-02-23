using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuService.Data;
using UgovorOZakupuService.Entities;
using UgovorOZakupuService.Helpers;
using UgovorOZakupuService.Models;
using UgovorOZakupuService.Services;

namespace UgovorOZakupuService.Controllers
{
        [ApiController]
        [Route("api/v1/ugovor")]
        [Produces("application/json")]
        [Authorize]
        public class UgovorController : ControllerBase
        {
            private readonly IUgovorRepository UgovorRepository;
            private readonly IUgovorHelper UgovorHelper;
            private readonly LinkGenerator LinkGenerator;
            private readonly IMapper Mapper;
            private readonly IKupacService KupacService;
            private readonly ILicnostService LicnostService;
            private readonly ILoggerService LoggerService;

            public UgovorController(
                IUgovorRepository ugovorRepository, 
                IUgovorHelper ugovorHelper,
                LinkGenerator linkGenerator, 
                IMapper mapper,
                IKupacService kupacService,
                ILicnostService licnostService,
                ILoggerService loggerService)
            {
                this.UgovorRepository = ugovorRepository;
                this.UgovorHelper = ugovorHelper;
                this.LinkGenerator = linkGenerator;
                this.Mapper = mapper;
                this.KupacService = kupacService;
                this.LicnostService = licnostService;
                this.LoggerService = loggerService;
            }

            [HttpGet]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            public ActionResult<List<UgovorDto>> GetUgovorList()
            {
                List<Ugovor> ugovorList = UgovorRepository.GetUgovorList();

                if (ugovorList == null || ugovorList.Count == 0)
                {
                    return NoContent();
                }

                for (int i = 0; i < ugovorList.Count; i++)
                {
                    ugovorList[i] = UgovorHelper.loadRepositories(ugovorList[i]);
                }

                List<UgovorDto> ugovorListDto = Mapper.Map<List<UgovorDto>>(ugovorList);

                foreach (UgovorDto udto in ugovorListDto)
                {
                    udto.Kupac = KupacService.GetKupacByIdAsync(udto.KupacID, Request).Result;
                    udto.Licnost = LicnostService.GetLicnostByIdAsync(udto.LicnostID, Request).Result;
                }

                LoggerService.createLogAsync("UgovorOZakupu", "Ugovor", "GET", 200);

                return Ok(ugovorListDto);
            }

            [HttpGet("{ugovorId}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public ActionResult<UgovorDto> GetUgovorById(Guid ugovorId)
            {
                Ugovor ugovor = UgovorRepository.GetUgovorById(ugovorId);

                if (ugovor == null)
                {
                    return NotFound();
                }

                ugovor = UgovorHelper.loadRepositories(ugovor);

                UgovorDto ugovorDto = Mapper.Map<UgovorDto>(ugovor);

                ugovorDto.Kupac = KupacService.GetKupacByIdAsync(ugovorDto.KupacID, Request).Result;
                ugovorDto.Licnost = LicnostService.GetLicnostByIdAsync(ugovorDto.LicnostID, Request).Result;

                LoggerService.createLogAsync("UgovorOZakupu", "Ugovor", "GET", 200);

                return Ok(ugovorDto);
            }

            [HttpPost]
            [Consumes("application/json")]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public ActionResult<UgovorConfirmationDto> CreateUgovor([FromBody] UgovorCreateDto ugovorDto)
            {
                try
                {
                    Ugovor ugovor = Mapper.Map<Ugovor>(ugovorDto);
                    UgovorConfirmationDto confirmation = UgovorRepository.CreateUgovor(ugovor);

                    string location = LinkGenerator.GetPathByAction("GetUgovorById", "Ugovor", new { ugovorId = confirmation.UgovorID });

                    LoggerService.createLogAsync("UgovorOZakupu", "Ugovor", "POST", 201);

                    return Created(location, Mapper.Map<UgovorConfirmationDto>(confirmation));
                }
                catch (Exception ex)
                {
                    LoggerService.createLogAsync("UgovorOZakupu", "Ugovor", "POST", 500);
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

            [HttpPut]
            [Consumes("application/json")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public ActionResult<UgovorConfirmationDto> UpdateUgovor(UgovorUpdateDto ugovorDto)
            {
                try
                {
                    Ugovor oldUgovor = UgovorRepository.GetUgovorById(ugovorDto.UgovorID);

                    if (oldUgovor == null)
                    {
                        return NotFound();
                    }

                    Ugovor ugovor = Mapper.Map<Ugovor>(ugovorDto);

                    Mapper.Map(ugovor, oldUgovor);

                    UgovorConfirmationDto confirmation = UgovorRepository.UpdateUgovor(ugovor);

                    LoggerService.createLogAsync("UgovorOZakupu", "Ugovor", "PUT", 200);

                    return Ok(Mapper.Map<UgovorConfirmationDto>(confirmation));
                }
                catch (Exception ex)
                {
                    LoggerService.createLogAsync("UgovorOZakupu", "Ugovor", "PUT", 500);
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

            [HttpDelete("{ugovorId}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public ActionResult<UgovorConfirmationDto> DeleteUgovor(Guid ugovorId)
            {
                try
                {
                    Ugovor ugovor = UgovorRepository.GetUgovorById(ugovorId);

                    if (ugovor == null)
                    {
                        return NotFound();
                    }

                    UgovorConfirmationDto confirmation = UgovorRepository.DeleteUgovor(ugovorId);

                    LoggerService.createLogAsync("UgovorOZakupu", "Ugovor", "DELETE", 200);

                    return Ok(Mapper.Map<UgovorConfirmationDto>(confirmation));
                }
                catch (Exception ex)
                {
                    LoggerService.createLogAsync("UgovorOZakupu", "Ugovor", "DELETE", 500);
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
