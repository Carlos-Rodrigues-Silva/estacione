using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto
{

    public class RespostaEnderecoDto
    {
        public int Id { get; set; }

        public string FormattedAddress { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public string NomeEstacionamento { get; set; }

        public string NomeLogradouro { get; set; }

        public string Numero { get; set; }

        public double PrecoHora { get; set; }

        public string FotoEstacionamento { get; set; }

    }
}
