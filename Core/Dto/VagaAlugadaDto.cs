using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto
{
    public class VagaAlugadaDto
    {
        public int Id { get; set; }

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
