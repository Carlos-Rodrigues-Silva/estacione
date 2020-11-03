using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entidades
{
    public class Logradouro : EntidadeBase
    {
        public string TipoLogradouro { get; set; }

        public int EnderecoId { get; set; }

        public Endereco Endereco { get; set; }
    }
}
