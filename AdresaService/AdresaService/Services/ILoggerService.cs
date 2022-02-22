using System.Threading.Tasks;

namespace AdresaService.Services
{
    public interface ILoggerService
    {
        Task createLogAsync(string mikroservis, string entitet, string zahtjev, int status);
    }
}
