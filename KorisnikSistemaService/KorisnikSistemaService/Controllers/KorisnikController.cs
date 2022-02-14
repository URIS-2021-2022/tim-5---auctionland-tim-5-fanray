using AutoMapper;
using KorisnikSistemaService.Data;
using KorisnikSistemaService.Entites;
using KorisnikSistemaService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KorisnikSistemaService.Controllers
{
    [ApiController]
    [Route("api/v1/korisnik")]
    [Produces("application/json")]
    public class KorisnikController : ControllerBase
    {
        private readonly IKorisnikRepository KorisnikRepository;
        private readonly LinkGenerator LinkGenerator;
        private readonly IMapper Mapper;

        public KorisnikController(IKorisnikRepository korisnikRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.KorisnikRepository = korisnikRepository;
            this.LinkGenerator = linkGenerator;
            this.Mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<KorisnikDto>> GetKorisnikList()
        {
            List<Korisnik> korisnikList = KorisnikRepository.GetKorisnikList();

            if (korisnikList == null || korisnikList.Count == 0)
            {
                return NoContent();
            }

            return Ok(Mapper.Map<List<KorisnikDto>>(korisnikList));
        }

        [HttpGet("{korisnikId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KorisnikDto> GetKorsnikById(Guid korisnikId)
        {
            Korisnik korisnik = KorisnikRepository.GetKorisnikById(korisnikId);

            if (korisnik == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<KorisnikDto>(korisnik));
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KorisnikConfirmationDto> CreateKorisnik([FromBody] KorisnikCreateDto korisnikDto)
        {
            try
            {
                Korisnik korisnik = Mapper.Map<Korisnik>(korisnikDto);
                KorisnikConfirmationDto confirmation = KorisnikRepository.CreateKorisnik(korisnik);

                string location = LinkGenerator.GetPathByAction("GetKorisnikById", "Korisnik", new { korisnikId = confirmation.KorisnikID });

                return Created(location, Mapper.Map<KorisnikConfirmationDto>(confirmation));
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
        public ActionResult<KorisnikConfirmationDto> UpdateKorisnik(KorisnikUpdateDto korisnikDto)
        {
            try
            {
                Korisnik oldKorisnik = KorisnikRepository.GetKorisnikById(korisnikDto.KorisnikID);

                if (oldKorisnik == null)
                {
                    return NotFound();
                }

                Korisnik korisnik = Mapper.Map<Korisnik>(korisnikDto);

                Mapper.Map(korisnik, oldKorisnik);

                KorisnikConfirmationDto confirmation = KorisnikRepository.UpdateKorisnik(korisnik);

                return Ok(Mapper.Map<KorisnikConfirmationDto>(confirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{korisnikId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KorisnikConfirmationDto> DeleteKorisnik(Guid korisnikId)
        {
            try
            {
                Korisnik korisnik = KorisnikRepository.GetKorisnikById(korisnikId);

                if (korisnik == null)
                {
                    return NotFound();
                }

                KorisnikConfirmationDto confirmation = KorisnikRepository.DeleteKorisnik(korisnikId);

                return Ok(Mapper.Map<KorisnikConfirmationDto>(confirmation));
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
