using KorisnikSistemaService.Entites;
using KorisnikSistemaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KorisnikSistemaService.Data
{
     public interface IKorisnikRepository
     {
        List<Korisnik> GetKorisnikList();
        Korisnik GetKorisnikById(Guid korisnikId);
        KorisnikConfirmationDto CreateKorisnik(Korisnik korisnik);
        KorisnikConfirmationDto UpdateKorisnik(Korisnik korisnik);
        KorisnikConfirmationDto DeleteKorisnik(Guid korisnikId);

        bool UserWithCredentialsExists(string korisnickoIme, string lozinka);
    }
}
