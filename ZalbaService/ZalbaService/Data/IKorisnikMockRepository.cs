namespace ZalbaService.Data
{
    public interface IKorisnikRepository
    {
        bool UserWithCredentialsExists(string korisnickoIme, string lozinka);
    }
}
