using Core.Entidades.OrdemAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IOrdemService
    {
        Task<Ordem> CriarOrdemAsync(string email, string cestaId);

        Task<IReadOnlyList<Ordem>> ObterOrdensAsync(string emailComprador);

        Task<Ordem> ObterOrdemPeloId(int id, string emailComprador);
    }
}
