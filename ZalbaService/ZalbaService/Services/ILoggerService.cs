using System.Threading.Tasks;

namespace ZalbaService.Services
{
    public interface ILoggerService
    {
        Task createLogAsync(string opis);
    }
}
