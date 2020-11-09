using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Extensions;
using Core.Interfaces;
using Infraestrutura.Data;
using Infraestrutura.Identity;
using Infraestrutura.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Configura��o com a conex�o com o banco de dados
            services.AddDbContext<DataContext>(options =>
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            // Configura��o com a conex�o do banco de dados do Identity
            services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlite(Configuration.GetConnectionString("IdentityConnection")));

            // Configura��o do servidor Redis
            services.AddSingleton<IConnectionMultiplexer>(c => {
                var configuration = ConfigurationOptions.Parse(Configuration.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(configuration);
            });

            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // Permite que o servidor receba header, met�dos da origem especificada
            services.AddCors(options => options.AddPolicy("CorsPolicy", policy =>
            {
                policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
            }));
            services.AddHttpClient();

            services.AddScoped<IBasketRepository, BasketRepository>();

            //Swagger - documenta��o de todos os m�todos dos controladores utlizando o Swagger UI.
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Estacione API", Version = "v1" });
            });

            // Servi�o que recebe dados de endere�os do Google Maps API.
            services.AddScoped<IGoogleRespostaEndereco, GoogleRespostaEndereco>();

            // Reposit�rio Gen�rico
            services.AddScoped(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));

            // Servi�o Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IOrdemService, OrdemService>();

            services.AddIdentityServices(Configuration);
            services.AddScoped<ITokenService, TokenService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            //Swagger - documenta��o de todos os m�todos dos controladores utlizando o Swagger UI.
            app.UseSwagger();
            app.UseSwaggerUI(c => 
            { 
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Estacione API v1"); 
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
