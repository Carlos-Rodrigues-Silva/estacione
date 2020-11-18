using API.Extensions;
using Core.Dto;
using Core.Entidades.OrdemAggregate;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdemController : ControllerBase
    {
        private readonly IOrdemService _ordemService;


        public OrdemController(IOrdemService ordemService)
        {
            _ordemService = ordemService;
        }

        [HttpPost]
        public async Task<ActionResult<Ordem>> CriarOrdem(OrdemDto ordemDto)
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();

            var ordem =  await _ordemService.CriarOrdemAsync(email, ordemDto.cestaId);

            if (ordem == null)
            {
                return BadRequest("Problema para criar a ordem");
            }
            return Ok(ordem);
        }

        [HttpGet("ordens")]
        public async Task<ActionResult<List<Ordem>>> ObterOrdens()
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();

            if (email == null) return NotFound();

            var ordens = await _ordemService.ObterOrdensAsync(email);

            return Ok(ordens);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrdemParaRetornarDto>> ObterOrdem(int id)
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();

            var ordem = await _ordemService.ObterOrdemPeloId(id, email);

            if(ordem == null)
            {
                return NotFound();
            }

            var ordemParaRetornarDto = new OrdemParaRetornarDto
            {
                Id = ordem.Id,
                EmailComprador = ordem.EmailComprador,
                DataOrdem = ordem.DataOrdem,

                Quantidade = ordem.VagaAlugadas[0].Quantidade,
                Preco = ordem.VagaAlugadas[0].Preco,
                NomeEstacionamento = ordem.VagaAlugadas[0].VagaOrdenada.NomeEstacionamento,
                NomeLogradouro = ordem.VagaAlugadas[0].VagaOrdenada.NomeLogradouro,
                Numero = ordem.VagaAlugadas[0].VagaOrdenada.Numero,
                Cep = ordem.VagaAlugadas[0].VagaOrdenada.Cep,
                Bairro = ordem.VagaAlugadas[0].VagaOrdenada.Bairro,
                Cidade = ordem.VagaAlugadas[0].VagaOrdenada.Cidade,
                Estado = ordem.VagaAlugadas[0].VagaOrdenada.Estado,

                Total = ordem.Total,
                StatusOrdem = ordem.StatusOrdem,
                PaymentIntentId = ordem.PaymentIntentId
            };


            return Ok(ordemParaRetornarDto);
        }
    }
}
