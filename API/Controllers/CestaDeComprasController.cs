using Core.Dto;
using Core.Entidades;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CestaDeComprasController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;

        public CestaDeComprasController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        [HttpGet]
        public async Task<ActionResult<CestaCliente>> GetBasketById(string id)
        {
            CestaCliente basket = await _basketRepository.GetBasketAsync(id);
            return Ok(basket ?? new CestaCliente(id));
        }

        [HttpPost]
        public async Task<ActionResult<CestaCliente>> UpdateBasket(CestaClienteDto cesta)
        {
            var cestaCliente = new CestaCliente
            {
                Id = cesta.Id,
                ItensCestaCliente = cesta.ItensCestaCliente,
                ClientSecret = cesta.ClientSecret,
                PaymentIntentId = cesta.PaymentIntentId
            };

            CestaCliente updatedBasket = await _basketRepository.UpdateBasketAsync(cestaCliente);

            return Ok(updatedBasket);
        }

        [HttpDelete]
        public async Task DeleteBasketAsync(string id)
        {
            await _basketRepository.DeleteBasketAsync(id);
        }
    }
}
