using Core.Entidades;
using Core.Interfaces;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Data
{
    public class BasketRepository : IBasketRepository
    {
        // Funcionalidades do servidor Redis
        public readonly IDatabase _database;


        public BasketRepository(IConnectionMultiplexer redis)
        {
            // Conexão com banco de dados do Redis
            _database = redis.GetDatabase();

        }

        // Deletar cesta de compras do usuário
        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _database.KeyDeleteAsync(basketId);
        }

        // Obter cesta de compras do usuário
        public async Task<CestaCliente> GetBasketAsync(string basketId)
        {
            var data = await _database.StringGetAsync(basketId);

            return data.IsNullOrEmpty ? null : JsonConvert.DeserializeObject<CestaCliente>(data);

        }

        // Atualizar cesta de compras do usuário
        // se ela não existir retornar uma nova cesta
        public async Task<CestaCliente> UpdateBasketAsync(CestaCliente basket)
        {
            var created = await _database.StringSetAsync(basket.Id, JsonConvert.SerializeObject(basket), TimeSpan.FromDays(30));

            if (!created) return null;

            return await GetBasketAsync(basket.Id);
        }
    }
}
