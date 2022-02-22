using KupacService.Helpers;
using KupacService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace KupacService.Services
{
    public class OvlascenoLiceService : IOvlascenoLiceService
    {
        private readonly IConfiguration Configuration;
        private readonly IAuthHelper AuthHelper;


        public OvlascenoLiceService(IConfiguration configuration, IAuthHelper authHelper)
        {
            this.Configuration = configuration;
            this.AuthHelper = authHelper;
        }

        public async Task<OvlascenoLiceDto> GetOvlascenoLiceByIdAsync(Guid ovlascenoLiceId, HttpRequest httpRequest)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri url = new Uri($"{ Configuration["Services:OvlascenoLice"] }/ovlasceno-lice/{ovlascenoLiceId}");

                string token = AuthHelper.GetToken(httpRequest);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = client.GetAsync(url).Result;

                var responseContent = await response.Content.ReadAsStringAsync();

                var ol = JsonConvert.DeserializeObject<OvlascenoLiceDto>(responseContent);

                return ol;
            }
        }
    }
}
