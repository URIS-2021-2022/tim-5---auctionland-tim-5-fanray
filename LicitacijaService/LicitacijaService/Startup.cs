using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using LicitacijaService.Data;
using LicitacijaService.Entities;
using System;
using System.Text;

namespace LicitacijaService
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
            services.AddScoped<IDokumentacijaRepository, DokumentacijaRepository>();
            services.AddScoped<IDokumentacijaZaFizickoLiceRepository, DokumentacijaZaFizickoLiceRepository>();
            services.AddScoped<IDokumentacijaZaPravnoLiceRepository, DokumentacijaZaPravnoLiceRepository>();
            services.AddScoped<ILicitacijaRepository, LicitacijaRepository>();

            services.AddControllers();

            services.AddDbContext<LicitacijaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LicitacijaDB")));

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
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "LicitacijaService", Version = "v1" }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(setupAction => setupAction.SwaggerEndpoint("/swagger/v1/swagger.json", "LicitacijaService API"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}