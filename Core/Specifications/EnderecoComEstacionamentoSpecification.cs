using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
    public class EnderecoComEstacionamentoSpecification : BaseSpecification<Endereco>
    {
        public EnderecoComEstacionamentoSpecification(string RuaOuCep) : base(x => x.NomeLogradouro.ToLower() == RuaOuCep.ToLower() || x.Cep.ToLower() == RuaOuCep.ToLower())
        {
            AddInclude(x => x.Estacionamento);
        }
    }
}
