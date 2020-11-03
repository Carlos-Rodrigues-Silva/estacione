using Core.Entidades.OrdemAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IServicoPagamento
    {
        Task<Ordem> CriarOrdemAsync();
    }
}
