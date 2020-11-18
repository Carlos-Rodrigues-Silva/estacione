using Core.Entidades;
using Core.Entidades.OrdemAggregate;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stripe;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicoPagamentoController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly ILogger<IPaymentService> _logger;
        private const string WhSecret = "";

        public ServicoPagamentoController(IPaymentService paymentService, ILogger<IPaymentService> logger)
        {
            _paymentService = paymentService;
            _logger = logger;
        }

        [Authorize]
        [HttpPost("{cestaId}")]
        public async Task<ActionResult<CestaCliente>> CriarOuAtualizarIntencaoCompra(string cestaId)
        {
            var cesta = await _paymentService.CriarOuAtualizarIntencaoCompra(cestaId);

            if (cesta == null)
            {
                return BadRequest(400);
            }

            return cesta;
        }

        [Authorize]
        [HttpGet]
        public string teste()
        {
            string nome = "oi amigo";
            return nome;
        }

        [HttpPost("webhook")]
        public async Task<ActionResult> StripeWebHook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            var stripeEvent = EventUtility.ConstructEvent(json, Request.Headers["Stripe-Signature"], WhSecret);

            PaymentIntent intent;
            Ordem ordem;

            switch (stripeEvent.Type)
            {
                case "payment_intent.succeeded":
                    intent = (PaymentIntent)stripeEvent.Data.Object;
                    _logger.LogInformation("Pagamento bem sucedido: ", intent.Id);
                    ordem = await _paymentService.AtualizarOrdemPagamentoSucesso(intent.Id);
                    _logger.LogInformation("Ordem atualizada com pagamento recebido: ", ordem.Id);
                    break;
                case "payment_intent.failed":
                    intent = (PaymentIntent)stripeEvent.Data.Object;
                    _logger.LogInformation("Pagamento Falhou: ", intent.Id);
                    ordem = await _paymentService.AtualizarOrdemPagamentoFalhou(intent.Id);
                    _logger.LogInformation("Pagamento Falhou: ", ordem.Id);
                    break;
            }

            return new EmptyResult();
        }
    }
}
