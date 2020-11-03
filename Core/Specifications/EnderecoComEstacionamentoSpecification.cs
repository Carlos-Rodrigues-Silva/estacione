using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
    public class EnderecoComEstacionamentoSpecification : BaseSpecification<Endereco>
    {
        public EnderecoComEstacionamentoSpecification(string RuaOuCep) : base(x => x.NomeLogradouro == RuaOuCep.ToLower() || x.Cep == RuaOuCep.ToLower())
        {
            AddInclude(x => x.Estacionamento);
        }
    }
}
