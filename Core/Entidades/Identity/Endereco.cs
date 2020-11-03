using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entidades.Identity
{
    public class Endereco
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Número { get; set; }

        public string TipoLogradouro { get; set; }

        public string Cep { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string AppUserId { get; set; }

        public AppUser AppUser { get; set; }
    }
}
