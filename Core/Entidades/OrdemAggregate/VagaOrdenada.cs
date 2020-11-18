using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entidades.OrdemAggregate
{
    public class VagaOrdenada
    {
        public VagaOrdenada() { }

        public VagaOrdenada(string nomeEstacionamento, string nomeLogradouro, string numero, string cep, string bairro, string cidade, string estado)
        {
            NomeEstacionamento = nomeEstacionamento;
            NomeLogradouro = nomeLogradouro;
            Numero = numero;
            Cep = cep;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }

        public string NomeEstacionamento { get; set; }

        public string NomeLogradouro { get; set; }

        public string Numero { get; set; }

        public string Cep { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }
    }
}
