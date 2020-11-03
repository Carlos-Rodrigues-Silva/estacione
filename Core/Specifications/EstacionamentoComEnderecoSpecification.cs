using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
    public class EstacionamentoComEnderecoSpecification : BaseSpecification<Estacionamento>
    {
        public EstacionamentoComEnderecoSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Endereco);
        }
    }
}
