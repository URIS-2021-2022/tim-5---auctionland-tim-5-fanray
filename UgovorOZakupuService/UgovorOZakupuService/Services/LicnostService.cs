using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UgovorOZakupuService.Helpers;
using UgovorOZakupuService.Models;

namespace UgovorOZakupuService.Services
{
    public class LicnostService : ILicnostService
    {
        private readonly IConfiguration Configuration;
        private readonly IAuthHelper AuthHelper;


        public LicnostService(IConfiguration configuration, IAuthHelper authHelper)
        {
            this.Configuration = configuration;
            this.AuthHelper = authHelper;
        }

        public async Task<LicnostDto> GetLicnostByIdAsync(Guid licnostId, HttpRequest httpRequest)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri url = new Uri($"{ Configuration["Services:Licnost"] }/licnost/{licnostId}");

                string token = AuthHelper.GetToken(httpRequest);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = client.GetAsync(url).Result;

                var responseContent = await response.Content.ReadAsStringAsync();

                var licnost = JsonConvert.DeserializeObject<LicnostDto>(responseContent);

                return licnost;
            }
        }
    }
}
