using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OvlascenoLiceService.Helpers;
using OvlascenoLiceService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OvlascenoLiceService.Services
{
    public class AdresaService : IAdresaService
    {
        private readonly IConfiguration Configuration;
        private readonly IAuthHelper AuthHelper;

        public AdresaService(IConfiguration configuration, IAuthHelper authHelper)
        {
            this.Configuration = configuration;
            this.AuthHelper = authHelper;
        }

        public async Task<DrzavaDto> GetDrzavaByIdAsync(Guid drzavaId, HttpRequest httpRequest)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri url = new Uri($"{ Configuration["Services:Adresa"] }/drzava/{drzavaId}");

                string token = AuthHelper.GetToken(httpRequest);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = client.GetAsync(url).Result;

                var responseContent = await response.Content.ReadAsStringAsync();

                var drzava = JsonConvert.DeserializeObject<DrzavaDto>(responseContent);

                return drzava;
            }
        }
    }
}
