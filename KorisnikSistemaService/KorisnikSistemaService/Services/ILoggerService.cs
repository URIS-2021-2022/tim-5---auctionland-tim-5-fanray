using System.Threading.Tasks;

namespace KorisnikSistemaService.Services
{
    public interface ILoggerService
    {
        Task createLogAsync(string opis);
    }
}
