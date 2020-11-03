using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Endereco : EntidadeBase
    {
        public string NomeLogradouro { get; set; }

        public string Numero { get; set; }

        public string Cep { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public int EstacionamentoId { get; set; }

        public Estacionamento Estacionamento { get; set; }

        public Logradouro Logradouro { get; set; }


    }
}
