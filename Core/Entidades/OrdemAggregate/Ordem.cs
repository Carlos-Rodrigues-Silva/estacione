using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entidades.OrdemAggregate
{
    public class Ordem : EntidadeBase
    {
        public Ordem() { }

        public Ordem(IReadOnlyList<VagaAlugada> vagaAlugada, string emailComprador, decimal total)
        {
            EmailComprador = emailComprador;
            VagaAlugadas = vagaAlugada;
            Total = total;
        }

        public string EmailComprador { get; set; }

        public DateTimeOffset DataOrdem { get; set; } = DateTimeOffset.Now;

        public IReadOnlyList<VagaAlugada> VagaAlugadas { get; set; }

        public decimal Total { get; set; }

        public StatusOrdem StatusOrdem { get; set; } = StatusOrdem.PagamentoPendente;

        public string PaymentIntentId { get; set; }
    }
}
