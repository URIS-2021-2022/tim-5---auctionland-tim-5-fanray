using AutoMapper;
using KorisnikSistemaService.Data;
using KorisnikSistemaService.Entites;
using KorisnikSistemaService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KorisnikSistemaService.Controllers
{
    [ApiController]
    [Route("api/v1/tip-korisnika")]
    [Produces("application/json")]
    [Authorize]
    public class TipKorisnikaController : ControllerBase
    {
        private readonly ITipKorisnikaRepository TipKorisnikaRepository;
        private readonly IMapper Mapper;

        public TipKorisnikaController(ITipKorisnikaRepository tipKorisnikaRepository, IMapper mapper)
        {
            this.TipKorisnikaRepository = tipKorisnikaRepository;
            this.Mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<TipKorisnikaDto>> GetTipKorisnikaList()
        {
            List<TipKorisnika> tipKorisnikaList = TipKorisnikaRepository.GetTipKorisnikaList();

            if (tipKorisnikaList == null || tipKorisnikaList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<TipKorisnikaDto>>(tipKorisnikaList));
        }

   
        [HttpGet("{tipKorisnikaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<TipKorisnikaDto> GetTipKorisnikaById(Guid tipKorisnikaId)
        {
            TipKorisnika tipKorisnika = TipKorisnikaRepository.GetTipKorisnikaById(tipKorisnikaId);

            if (tipKorisnika == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<TipKorisnikaDto>(tipKorisnika));
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
