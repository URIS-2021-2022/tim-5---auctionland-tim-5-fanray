using AdresaService.Data;
using AdresaService.Entities;
using AdresaService.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaService.Controllers
{
    [ApiController]
    [Route("api/v1/drzava")]
    [Produces("application/json")]
    [Authorize]
    public class DrzavaController : ControllerBase
    { 

            private readonly IDrzavaRepository DrzavaRepository;
            private readonly IMapper Mapper;

            public DrzavaController(IDrzavaRepository drzavaRepository, IMapper mapper)
            {
                this.DrzavaRepository = drzavaRepository;
                this.Mapper = mapper;
            }

            /// <summary>
            /// Vraca listu svih drzava
            /// </summary>
            /// <returns></returns>
            /// <response code="200">Vraca listu svih drzava</response>
            /// <response code="204">Nema drzava</response>
            [HttpGet]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            public ActionResult<List<DrzavaDto>> GetDrzavaList()
            {
                List<Drzava> drzavaList = DrzavaRepository.GetDrzavaList();

                if (drzavaList == null || drzavaList.Count == 0)
                {
                    return NoContent();
                }

                return Ok(Mapper.Map<List<DrzavaDto>>(drzavaList));
            }

            /// <summary>
            /// Vraca drzavu sa trazenim ID-em
            /// </summary>
            /// <param name="drzavaId">Sifra drzave</param>
            /// <returns></returns>
            /// <response code="200">Vraca trazenu drzavu</response>
            /// <response code="404">Drzava nije pronadjena</response>
            [HttpGet("{drzavaId}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public ActionResult<DrzavaDto> GetDrzavaById(Guid drzavaId)
            {
                Drzava drzava = DrzavaRepository.GetDrzavaById(drzavaId);

                if (drzava == null)
                {
                    return NotFound();
                }

                return Ok(Mapper.Map<DrzavaDto>(drzava));
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

