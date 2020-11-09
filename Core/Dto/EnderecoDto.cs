using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto
{
    public class EnderecoDto
    {
        public string Nome { get; set; }

        public string Número { get; set; }

        public string TipoLogradouro { get; set; }

        public string Cep { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }
    }
}
