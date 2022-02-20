using System.Threading.Tasks;

namespace JavnoNadmetanjeService.Services
{
    public interface ILoggerService
    {
        Task createLogAsync(string opis);
    }
}
