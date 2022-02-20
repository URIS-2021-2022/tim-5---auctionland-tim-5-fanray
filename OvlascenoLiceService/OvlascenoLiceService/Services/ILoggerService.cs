using System.Threading.Tasks;

namespace OvlascenoLiceService.Services
{
    public interface ILoggerService
    {
        Task createLogAsync(string opis);
    }
}
