using Core.Entidades;
using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRepositorioGenerico<T> where T : class
    {
        Task<List<T>> ListarTodosAsync();

        Task<List<T>> ListarTodosAsync(ISpecification<T> specification);

        Task<T> ObterEntidadePeloId(int id);

        Task<T> ObterEntidadeComSpec(ISpecification<T> specification);

        void Adicionar(T entidade);

        void Atualizar(T entidade);

        void Deletar(T entidade);
    }
}
