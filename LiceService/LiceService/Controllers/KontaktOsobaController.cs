using AutoMapper;
using LiceService.Data;
using LiceService.Entities;
using LiceService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceService.Controllers
{

    [ApiController]
    [Route("api/v1/kontaktOsoba")]
    [Produces("application/json")]
    //[Authorize]
    public class KontaktOsobaController : ControllerBase
    {

    private readonly IKontaktOsobaRepository KontaktOsobaRepository;
    private readonly IMapper Mapper;

    public KontaktOsobaController(IKontaktOsobaRepository kontaktOsobaRepository, IMapper mapper)
    {
        this.KontaktOsobaRepository = kontaktOsobaRepository;
        this.Mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult<List<KontaktOsobaDto>> GetKontaktOsobaList()
    {
        List<KontaktOsoba> kontaktOsobaList = KontaktOsobaRepository.GetKontaktOsobaList();

        if (kontaktOsobaList == null || kontaktOsobaList.Count == 0)
        {
            return NoContent();
        }

        return Ok(Mapper.Map<List<KontaktOsobaDto>>(kontaktOsobaList));
    }

    [HttpGet("{kontaktOsobaId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<KontaktOsobaDto> GetKontaktOsobaById(Guid kontaktOsobaId)
    {
            KontaktOsoba kontaktOsoba = KontaktOsobaRepository.GetKontaktOsobaById(kontaktOsobaId);

        if (kontaktOsoba == null)
        {
            return NotFound();
        }

        return Ok(Mapper.Map<KontaktOsobaDto>(kontaktOsoba));
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