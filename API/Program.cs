using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Infraestrutura.Data;
using Infraestrutura.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Aplicar as migrações e criar banco de dados (se ele não existir)
            IHost host = CreateHostBuilder(args).Build();

            using(IServiceScope scope = host.Services.CreateScope())
            {
                IServiceProvider services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    DataContext context = services.GetRequiredService<DataContext>();
                    await context.Database.MigrateAsync();
                    await DataContextSeed.SeedData(context, loggerFactory);

                    UserManager<AppUser> userManager = services.GetRequiredService<UserManager<AppUser>>();
                    AppIdentityDbContext identityDbContext = services.GetRequiredService<AppIdentityDbContext>();
                    await identityDbContext.Database.MigrateAsync();
                    await AppIdentityDbContextSeedData.AppIdentitySeedData(userManager);

                }
                catch (Exception)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError("Um erro ocorreu durante a migração");
                }
            }

            host.Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
