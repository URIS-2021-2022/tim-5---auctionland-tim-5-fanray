using AutoMapper;
using LoggerService.Data;
using LoggerService.Entities;
using LoggerService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;

namespace LoggerService.Controllers
{
    [ApiController]
    [Route("api/v1/log")]
    [Produces("application/json")]
    public class LogController : ControllerBase
    {
        private readonly ILogRepository LogRepository;
        private readonly LinkGenerator LinkGenerator;
        private readonly IMapper Mapper;

        public LogController(ILogRepository logRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.LogRepository = logRepository;
            this.LinkGenerator = linkGenerator;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Vraca listu svih logova
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Vraca listu svih logova</response>
        /// <response code="204">Nema logova</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<LogDto>> GetLogList()
        {
            List<Log> logList = LogRepository.GetLogList();

            if (logList == null || logList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<LogDto>>(logList));
        }

        /// <summary>
        /// Vraca log sa trazenim ID-em
        /// </summary>
        /// <param name="logId">Sifra loga</param>
        /// <returns></returns>
        /// <response code="200">Vraca trazeni log</response>
        /// <response code="404">Log nije pronadjen</response>
        [HttpGet("{logId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<LogDto> GetLogById(Guid logId)
        {
            Log log = LogRepository.GetLogById(logId);

            if (log == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<LogDto>(log));
        }

        /// <summary>
        /// Upis novog loga
        /// </summary>
        /// <returns></returns>
        /// <response code="201">Vraca kreirani log</response>
        /// <response code="500">Doslo je do greske na serveru prilikom kreiranja loga</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<LogConfirmationDto> CreateLog([FromBody] LogCreateDto logDto)
        {
            try
            {
                DateTime dt = DateTime.Now;

                Log log = Mapper.Map<Log>(logDto);

                log.DatumKreiranja = dt.Date.ToString();
                log.VremeKreiranja = dt.TimeOfDay.ToString();

                LogConfirmationDto confirmation = LogRepository.CreateLog(log);

                string location = LinkGenerator.GetPathByAction("GetLogById", "Log", new { logId = confirmation.LogID });

                return Created(location, Mapper.Map<LogConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
