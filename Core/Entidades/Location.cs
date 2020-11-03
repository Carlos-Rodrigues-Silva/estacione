using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entidades
{
    public class Location : EntidadeBase
    {
        public string FormattedAddress { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public string NomeEstacionamento { get; set; }

        public string NomeLogradouro { get; set; }

        public string Numero { get; set; }

        public double PrecoHora { get; set; }
    }
}
