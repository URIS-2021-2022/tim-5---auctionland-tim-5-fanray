namespace ParcelaService.Data
{
    public interface IKorisnikRepository
    {
        bool UserWithCredentialsExists(string korisnickoIme, string lozinka);
    }
}
