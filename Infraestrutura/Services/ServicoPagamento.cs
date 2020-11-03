using Core.Entidades.OrdemAggregate;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Services
{
    public class ServicoPagamento : IServicoPagamento
    {
        public Task<Ordem> CriarOrdemAsync()
        {
            throw new NotImplementedException();
        }
    }
}
