using System.Threading.Tasks;

namespace LicitacijaService.Services
{
    public interface ILoggerService
    {
        Task createLogAsync(string opis);
    }
}
