using Core.Entidades;
using Core.Entidades.OrdemAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPaymentService
    {
        Task<CestaCliente> CriarOuAtualizarIntencaoCompra(string cestaId);

        Task<Ordem> AtualizarOrdemPagamentoSucesso(string paymentIntentId);

        Task<Ordem> AtualizarOrdemPagamentoFalhou(string paymentIntentId);

    }
}
