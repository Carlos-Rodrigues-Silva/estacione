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
                // Verificar se existe alguma informação no banco de dados
                // se não existir entrar no bloco
                if(!context.Estacionamentos.Any())
                {
                    // Ler arquivo Json com os dados para serem salvos no banco
                    string estacionamentoData = File.ReadAllText("../Infraestrutura/Data/SeedData/Estacionamento.json");

                    // Transformar esse texto em um objeto
                    //List<Estacionamento> estacionamento = JsonSerializer.Deserialize<List<Estacionamento>>(estacionamentoData);
                    List<Estacionamento> estacionamento = JsonConvert.DeserializeObject<List<Estacionamento>>(estacionamentoData);


                    foreach (Estacionamento item in estacionamento)
                    {
                        await context.Estacionamentos.AddAsync(item);
                    }

                    await context.SaveChangesAsync();
                }

                // Verificar se existe alguma informação no banco de dados
                // se não existir entrar no bloco
                if (!context.Enderecos.Any())
                {
                    // Ler arquivo Json com os dados para serem salvos no banco
                    string enderecoData = File.ReadAllText("../Infraestrutura/Data/SeedData/Endereco.json");

                    // Transformar esse texto em um objeto
                    //List<Endereco> enderecos = JsonSerializer.Deserialize<List<Endereco>>(enderecoData);
                    List<Endereco> enderecos = JsonConvert.DeserializeObject<List<Endereco>>(enderecoData);



                    foreach (Endereco item in enderecos)
                    {
                        await context.Enderecos.AddAsync(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Logradouros.Any())
                {
                    // Ler arquivo Json com os dados para serem salvos no banco
                    string logradouroData = File.ReadAllText("../Infraestrutura/Data/SeedData/Logradouro.json");

                    // Transformar esse texto em um objeto
                    //List<Logradouro> logradouros = JsonSerializer.Deserialize<List<Logradouro>>(logradouroData);
                    List<Logradouro> logradouros = JsonConvert.DeserializeObject<List<Logradouro>>(logradouroData);


                    foreach (Logradouro item in logradouros)
                    {
                        await context.Logradouros.AddAsync(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Locations.Any())
                {
                    // Ler arquivo Json com os dados para serem salvos no banco
                    string locationData = File.ReadAllText("../Infraestrutura/Data/SeedData/Location.json");

                    // Transformar esse texto em um objeto
                    //List<Location> locations = JsonSerializer.Deserialize<List<Location>>(locationData);
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
