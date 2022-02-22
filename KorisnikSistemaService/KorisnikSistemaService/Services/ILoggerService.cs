using System.Threading.Tasks;

namespace KorisnikSistemaService.Services
{
    public interface ILoggerService
    {
        Task createLogAsync(string mikroservis, string entitet, string zahtjev, int status);
    }
}
