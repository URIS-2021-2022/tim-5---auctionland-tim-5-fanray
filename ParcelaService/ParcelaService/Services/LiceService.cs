using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ParcelaService.Helpers;
using ParcelaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ParcelaService.Services
{
    public class LiceService : ILiceService
    {
        private readonly IConfiguration Configuration;
        private readonly IAuthHelper AuthHelper;

        public LiceService(IConfiguration configuration, IAuthHelper authHelper)
        {
            this.Configuration = configuration;
            this.AuthHelper = authHelper;
        }

        public async Task<LiceDto> GetLiceByIdAsync(Guid liceId, HttpRequest httpRequest)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri url = new Uri($"{ Configuration["Services:Lice"] }/lice/{liceId}");

                string token = AuthHelper.GetToken(httpRequest);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = client.GetAsync(url).Result;

                var responseContent = await response.Content.ReadAsStringAsync();

                var lice = JsonConvert.DeserializeObject<LiceDto>(responseContent);

                return lice;
            }
        }
    }
}
