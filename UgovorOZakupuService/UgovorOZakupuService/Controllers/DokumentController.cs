using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuService.Data;
using UgovorOZakupuService.Entities;
using UgovorOZakupuService.Models;

namespace UgovorOZakupuService.Controllers
{       
        [ApiController]
        [Route("api/v1/dokument")]
        [Produces("application/json")]
        [Authorize]
        public class DokumentController : ControllerBase
        {
            private readonly IDokumentRepository DokumentRepository;
            private readonly IMapper Mapper;

            public DokumentController(IDokumentRepository dokumentRepository, IMapper mapper)
            {
                this.DokumentRepository = dokumentRepository;
                this.Mapper = mapper;
            }

            [HttpGet]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            public ActionResult<List<DokumentDto>> GetDokumentList()
            {
                List<Dokument> dokumentList = DokumentRepository.GetDokumentList();

                if (dokumentList == null || dokumentList.Count == 0)
                {
                    return NoContent();
                }

                return Ok(Mapper.Map<List<DokumentDto>>(dokumentList));
            }


            [HttpGet("{dokumentId}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public ActionResult<DokumentDto> GetDokumentById(Guid dokumentId)
            {
                Dokument dokument = DokumentRepository.GetDokumentById(dokumentId);

                if (dokument == null)
                {
                    return NotFound();
                }

                return Ok(Mapper.Map<DokumentDto>(dokument));
            }

            [HttpOptions]
            [AllowAnonymous]
            public IActionResult GetExamRegistrationOptions()
            {
                Response.Headers.Add("Allow", "GET");

                return Ok();
            }
        }
}
