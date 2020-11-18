using Core.Entidades;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infraestrutura.Data
{
    public class DataContextSeed
    {
        public static async Task SeedData(DataContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if(!context.Estacionamentos.Any())
                {
                    string estacionamentoData = File.ReadAllText("../Infraestrutura/Data/SeedData/Estacionamento.json");

                    List<Estacionamento> estacionamento = JsonConvert.DeserializeObject<List<Estacionamento>>(estacionamentoData);


                    foreach (Estacionamento item in estacionamento)
                    {
                        await context.Estacionamentos.AddAsync(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Enderecos.Any())
                {
                    string enderecoData = File.ReadAllText("../Infraestrutura/Data/SeedData/Endereco.json");

                    List<Endereco> enderecos = JsonConvert.DeserializeObject<List<Endereco>>(enderecoData);

                    foreach (Endereco item in enderecos)
                    {
                        await context.Enderecos.AddAsync(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Logradouros.Any())
                {
                    string logradouroData = File.ReadAllText("../Infraestrutura/Data/SeedData/Logradouro.json");

                    List<Logradouro> logradouros = JsonConvert.DeserializeObject<List<Logradouro>>(logradouroData);


                    foreach (Logradouro item in logradouros)
                    {
                        await context.Logradouros.AddAsync(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Locations.Any())
                {
                    string locationData = File.ReadAllText("../Infraestrutura/Data/SeedData/Location.json");

                    var locations = JsonConvert.DeserializeObject<List<Location>>(locationData);

                    foreach (Location item in locations)
                    {
                        await context.Locations.AddAsync(item);
                    }

                    await context.SaveChangesAsync();

                }
            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<DataContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
