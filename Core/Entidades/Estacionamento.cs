using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Estacionamento : EntidadeBase
    {
        public string NomeEstacionamento { get; set; }
  
        public string Descricao { get; set; }

        public double PrecoHora { get; set; }

        public double Avaliacao { get; set; }

        public int NumeroVagas { get; set; }

        public int NumeroVagasDisponiveis { get; set; }

        public Endereco Endereco { get; set; }

    }
}
