using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepositorioGenerico<T> Repositorio<T>() where T : class;

        Task<int> Complete();
    }
}
