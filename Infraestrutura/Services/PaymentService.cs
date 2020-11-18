using Core.Entidades;
using Core.Entidades.OrdemAggregate;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;

        public PaymentService(IBasketRepository basketRepository, IUnitOfWork unitOfWork, IConfiguration config)
        {
            _basketRepository = basketRepository;
            _unitOfWork = unitOfWork;
            _config = config;
        }
        public async Task<CestaCliente> CriarOuAtualizarIntencaoCompra(string cestaId)
        {
            StripeConfiguration.ApiKey = _config["StripeSettings:SecretKey"];

            CestaCliente cestaComprasCliente = await _basketRepository.GetBasketAsync(cestaId);

            foreach (var item in cestaComprasCliente.ItensCestaCliente)
            {
                var estacionamento = await _unitOfWork.Repositorio<Estacionamento>().ObterEntidadePeloId(item.Id);
                if (item.Preco != (decimal)estacionamento.PrecoHora)
                {
                    item.Preco = (decimal)estacionamento.PrecoHora;
                }
            }

            PaymentIntentService service = new PaymentIntentService();

            PaymentIntent intent;

            if(string.IsNullOrEmpty(cestaComprasCliente.PaymentIntentId))
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long)cestaComprasCliente.ItensCestaCliente.Sum(i => i.Quantidade * (i.Preco * 100)),
                    Currency = "brl",
                    PaymentMethodTypes = new List<string> { "card" }
                };

                intent = await service.CreateAsync(options);
                cestaComprasCliente.PaymentIntentId = intent.Id;
                cestaComprasCliente.ClientSecret = intent.ClientSecret;
            }
            else
            {
                var options = new PaymentIntentUpdateOptions
                {
                    Amount = (long)cestaComprasCliente.ItensCestaCliente.Sum(i => i.Quantidade * (i.Preco * 100)),
                };
                await service.UpdateAsync(cestaComprasCliente.PaymentIntentId, options);
            }
            await _basketRepository.UpdateBasketAsync(cestaComprasCliente);

            return cestaComprasCliente;
        }



        public async Task<Ordem> AtualizarOrdemPagamentoSucesso(string paymentIntentId)
        {
            var spec = new OrdemPorPaymentIntentIdSpecification(paymentIntentId);
            var ordem = await _unitOfWork.Repositorio<Ordem>().ObterEntidadeComSpec(spec);

            if (ordem == null) return null;

            ordem.StatusOrdem = StatusOrdem.PagamentoRecebido;
            _unitOfWork.Repositorio<Ordem>().Atualizar(ordem);

            await _unitOfWork.Complete();

            return ordem;
        }

        public async Task<Ordem> AtualizarOrdemPagamentoFalhou(string paymentIntentId)
        {
            var spec = new OrdemPorPaymentIntentIdSpecification(paymentIntentId);
            var ordem = await _unitOfWork.Repositorio<Ordem>().ObterEntidadeComSpec(spec);

            if (ordem == null) return null;

            ordem.StatusOrdem = StatusOrdem.PagamentoRecusado;

            await _unitOfWork.Complete();

            return ordem;

        }
    }
}
