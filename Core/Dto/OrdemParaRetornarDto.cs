using Core.Entidades.OrdemAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto
{
    public class OrdemParaRetornarDto
    {
        public int Id { get; set; }

        public string EmailComprador { get; set; }

        public DateTimeOffset DataOrdem { get; set; } 

        public decimal Total { get; set; }

        public StatusOrdem StatusOrdem { get; set; }

        public string PaymentIntentId { get; set; }

        public int Quantidade { get; set; }

        public decimal Preco { get; set; }

        public string NomeEstacionamento { get; set; }

        public string NomeLogradouro { get; set; }

        public string Numero { get; set; }

        public string Cep { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }
    }
}
