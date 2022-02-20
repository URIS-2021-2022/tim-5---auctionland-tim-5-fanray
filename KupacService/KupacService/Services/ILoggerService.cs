using System.Threading.Tasks;

namespace KupacService.Services
{
    public interface ILoggerService
    {
        Task createLogAsync(string opis);
    }
}
