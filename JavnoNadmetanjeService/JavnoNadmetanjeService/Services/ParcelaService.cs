using JavnoNadmetanjeService.Helpers;
using JavnoNadmetanjeService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JavnoNadmetanjeService.Services
{
    public class ParcelaService : IParcelaService
    {
        private readonly IConfiguration Configuration;
        private readonly IAuthHelper AuthHelper;

        public ParcelaService(IConfiguration configuration, IAuthHelper authHelper)
        {
            this.Configuration = configuration;
            this.AuthHelper = authHelper;
        }

        public async Task<KatastarskaOpstinaDto> GetKatastarskaOpstinaByIdAsync(Guid katastarId, HttpRequest httpRequest)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri url = new Uri($"{ Configuration["Services:Parcela"] }/katastar/{katastarId}");

                string token = AuthHelper.GetToken(httpRequest);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = client.GetAsync(url).Result;

                var responseContent = await response.Content.ReadAsStringAsync();

                var katastar = JsonConvert.DeserializeObject<KatastarskaOpstinaDto>(responseContent);

                return katastar;
            }
        }
    }
}
