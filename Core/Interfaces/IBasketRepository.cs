using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces

{
    public interface IBasketRepository
    {
        // Obter cesta de itens do usuário
        Task<CestaCliente> GetBasketAsync(string basketId);

        // Criar ou atualizar cesta de itens do usuário
        Task<CestaCliente> UpdateBasketAsync(CestaCliente basket);

        // Deletar item de cesta do usuário
        Task<bool> DeleteBasketAsync(string basketId);
    }
}
