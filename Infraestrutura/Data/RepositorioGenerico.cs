using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Data
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {
        private readonly DataContext _dataContext;

        public RepositorioGenerico(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<T>> ListarTodosAsync()
        {
            return await _dataContext.Set<T>().ToListAsync();
        }

        public async Task<List<T>> ListarTodosAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        public async Task<T> ObterEntidadeComSpec(ISpecification<T> specification)
        {
           return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(_dataContext.Set<T>().AsQueryable(), specification);
        }
        public void Adicionar(T entidade)
        {
            _dataContext.Set<T>().Add(entidade);
        }

        public void Atualizar(T entidade)
        {
            _dataContext.Set<T>().Attach(entidade);
            _dataContext.Entry(entidade).State = EntityState.Modified;
        }

        public void Deletar(T entidade)
        {
            _dataContext.Set<T>().Remove(entidade);
        }

        public async Task<T> ObterEntidadePeloId(int id)
        {
            return await _dataContext.Set<T>().FindAsync(id);
        }
    }
}
