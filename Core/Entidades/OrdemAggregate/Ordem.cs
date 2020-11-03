using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entidades.OrdemAggregate
{
    /// <summary>
    /// Classe que agrega todas as outras classes responsáveis por gerar ordens de compra no sistema
    /// </summary>
    public class Ordem : EntidadeBase
    {
        public Ordem() { }

        public Ordem(IReadOnlyList<VagaAlugada> vagaAlugada, string emailComprador, decimal total /*string paymentIntentId*/)
        {
            EmailComprador = emailComprador;
            VagaAlugadas = vagaAlugada;
            Total = total;
            //PaymentIntentId = paymentIntentId;
        }

        public string EmailComprador { get; set; }

        public DateTimeOffset DataOrdem { get; set; } = DateTimeOffset.Now;

        public IReadOnlyList<VagaAlugada> VagaAlugadas { get; set; }

        public decimal Total { get; set; }

        public StatusOrdem StatusOrdem { get; set; } = StatusOrdem.PagamentoPendente;

        // Usar isso pra verificar se já uma ordem antes e ir tentar criar uma com o mesmo PaymentIntentId
        public string PaymentIntentId { get; set; }
    }
}
