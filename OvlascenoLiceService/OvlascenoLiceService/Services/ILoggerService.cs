using System.Threading.Tasks;

namespace OvlascenoLiceService.Services
{
    public interface ILoggerService
    {
        Task createLogAsync(string mikroservis, string entitet, string zahtjev, int status);
    }
}
