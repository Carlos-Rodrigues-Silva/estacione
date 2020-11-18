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
        public readonly IDatabase _database;

        public BasketRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();

        }

        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _database.KeyDeleteAsync(basketId);
        }

        public async Task<CestaCliente> GetBasketAsync(string basketId)
        {
            var data = await _database.StringGetAsync(basketId);

            return data.IsNullOrEmpty ? null : JsonConvert.DeserializeObject<CestaCliente>(data);

        }

        public async Task<CestaCliente> UpdateBasketAsync(CestaCliente cesta)
        {
            var criarOuAtualizarCesta = await _database.StringSetAsync(cesta.Id, JsonConvert.SerializeObject(cesta), TimeSpan.FromDays(30));

            if (!criarOuAtualizarCesta) return null;

            return await GetBasketAsync(cesta.Id);
        }
    }
}
