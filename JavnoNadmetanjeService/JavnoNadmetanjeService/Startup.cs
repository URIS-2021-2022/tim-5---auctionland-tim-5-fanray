using JavnoNadmetanjeService.Data;
using JavnoNadmetanjeService.Entities;
using JavnoNadmetanjeService.Helpers;
using JavnoNadmetanjeService.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JavnoNadmetanjeService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddScoped<IJavnoNadmetanjeRepository, JavnoNadmetanjeRepository>();
            services.AddScoped<ITipJavnogNadmetanjaRepository, TipJavnogNadmetanjaRepository>();
            services.AddScoped<IStatusJavnogNadmetanjaRepository, StatusJavnogNadmetanjaRepository>();
            services.AddScoped<ISluzbeniListRepository, SluzbeniListRepository>();
            services.AddSingleton<IKorisnikRepository, KorisnikMockRepository>();
            services.AddScoped<IAuthHelper, AuthHelper>();
            services.AddScoped<IParcelaService, ParcelaService>();
            services.AddSingleton<ILoggerService, LoggerService>();

            services.AddControllers();

            services.AddDbContext<JavnoNadmetanjeContext>(options => options.UseSqlServer(Configuration.GetConnectionString("JavnoNadmetanjeDB")));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JavnoNadmetanjeService", Version = "v1" });

                var xmlComments = $"{ Assembly.GetExecutingAssembly().GetName().Name }.xml";
                var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlComments);

                c.IncludeXmlComments(xmlCommentsPath);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(setupAction => setupAction.SwaggerEndpoint("/swagger/v1/swagger.json", "JavnoNadmetanjeService API"));

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
