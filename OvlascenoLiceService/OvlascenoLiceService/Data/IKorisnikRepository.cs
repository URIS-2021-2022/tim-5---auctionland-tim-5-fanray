namespace OvlascenoLiceService.Data
{
    public interface IKorisnikRepository
    {
        bool UserWithCredentialsExists(string korisnickoIme, string lozinka);
    }
}