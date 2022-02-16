using System.Threading.Tasks;

namespace ParcelaService.Services
{
    public interface ILoggerService
    {
        Task createLogAsync(string opis);
    }
}
