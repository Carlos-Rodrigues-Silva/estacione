using Core.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private Hashtable _repositorios;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public async Task<int> Complete()
        {
           return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IRepositorioGenerico<T> Repositorio<T>() where T : class
        {
            if(_repositorios == null)
            {
                _repositorios = new Hashtable();
            }

            string tipo = typeof(T).Name;

            if(!_repositorios.ContainsKey(tipo))
            {
                Type tipoRepositorio = typeof(RepositorioGenerico<>);
                object instanciaRepositorio = Activator.CreateInstance(tipoRepositorio.MakeGenericType(typeof(T)), _context);

                _repositorios.Add(tipo, instanciaRepositorio);
            }

            return (RepositorioGenerico<T>)_repositorios[tipo];
        }
    }
}
