using Core.Entidades.OrdemAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
    public class OrdemComVagasOrdenadasSpecification : BaseSpecification<Ordem>
    {
        public OrdemComVagasOrdenadasSpecification(int id, string email) : base(e => e.Id == id && e.EmailComprador == email)
        {
            AddInclude(x => x.VagaAlugadas);
        }

        public OrdemComVagasOrdenadasSpecification(string email) : base(e => e.EmailComprador == email)
        {
            AddInclude(x => x.VagaAlugadas);
        }
    }
}
