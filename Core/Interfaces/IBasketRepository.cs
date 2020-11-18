using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces

{
    public interface IBasketRepository
    {
        Task<CestaCliente> GetBasketAsync(string basketId);

        Task<CestaCliente> UpdateBasketAsync(CestaCliente basket);

        Task<bool> DeleteBasketAsync(string basketId);
    }
}
