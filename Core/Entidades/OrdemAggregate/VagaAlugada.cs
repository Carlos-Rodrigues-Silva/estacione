using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entidades.OrdemAggregate
{
    public class VagaAlugada : EntidadeBase
    {
        public VagaAlugada() { }

        public VagaAlugada(VagaOrdenada vagaOrdenada, decimal preco, int quantidade)
        {
            VagaOrdenada = vagaOrdenada;
            Quantidade = quantidade;
            Preco = preco;
        }

        public VagaOrdenada VagaOrdenada { get; set; }

        public int Quantidade { get; set; }

        public decimal Preco { get; set; }
    }
}
