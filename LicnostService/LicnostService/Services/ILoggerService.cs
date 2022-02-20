using System.Threading.Tasks;

namespace LicnostService.Services
{
    public interface ILoggerService
    {
        Task createLogAsync(string opis);
    }
}
