using ParcelaService.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ParcelaService.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly IConfiguration Configuration;
        private readonly IHttpClientFactory HttpClientFactory;

        public LoggerService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            this.Configuration = configuration;
            this.HttpClientFactory = httpClientFactory;
        }

        public async Task createLogAsync(string mikroservis, string entitet, string zahtjev, int status)
        {
            LogCreateDto logDto = new LogCreateDto
            {
                Mikroservis = mikroservis,
                Entitet = entitet,
                Zahtjev = zahtjev,
                Status = status
            };

            var log = JsonSerializer.Serialize(logDto);
            var content = new StringContent(log, Encoding.UTF8, "application/json");

            HttpClient httpClient = HttpClientFactory.CreateClient();

            using var response = await httpClient.PostAsync(Configuration["Services:Logger"], content);
        }
    }
}
