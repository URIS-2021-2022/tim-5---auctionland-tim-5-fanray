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
            private readonly LinkGenerator LinkGenerator;
            private readonly IMapper Mapper;
            private readonly ILoggerService LoggerService;

            public UgovorController(IUgovorRepository ugovorRepository, LinkGenerator linkGenerator, IMapper mapper, ILoggerService loggerService)
            {
                this.UgovorRepository = ugovorRepository;
                this.LinkGenerator = linkGenerator;
                this.Mapper = mapper;
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

                return Ok(Mapper.Map<List<UgovorDto>>(ugovorList));
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

                return Ok(Mapper.Map<UgovorDto>(ugovor));
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

                    LoggerService.createLogAsync("Ugovor " + ugovor.UgovorID + " je dodat");

                    return Created(location, Mapper.Map<UgovorConfirmationDto>(confirmation));
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

                    LoggerService.createLogAsync("Ugovor " + ugovor.UgovorID + " je ažuriran");

                    return Ok(Mapper.Map<UgovorConfirmationDto>(confirmation));
                }
                catch (Exception ex)
                {
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

                    LoggerService.createLogAsync("Ugovor " + ugovor.UgovorID + " je izbrisan");

                    return Ok(Mapper.Map<UgovorConfirmationDto>(confirmation));
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
