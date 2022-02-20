using LicnostService.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LicnostService.Services
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

        public async Task createLogAsync(string opis)
        {
            LogCreateDto logDto = new LogCreateDto
            {
                Opis = opis
            };

            var log = JsonSerializer.Serialize(logDto);
            var content = new StringContent(log, Encoding.UTF8, "application/json");

            HttpClient httpClient = HttpClientFactory.CreateClient();

            using var response = await httpClient.PostAsync(Configuration["Services:Logger"], content);
        }
    }
}
