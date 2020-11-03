using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entidades
{
    public class CestaCliente
    {
        public CestaCliente() { }

        public CestaCliente(string id) => Id = id;
 
        public string Id { get; set; }

        public List<BasketItem> ItensCestaCliente { get; set; } = new List<BasketItem>();

        //// Usada pelo Stripe para o usuário confirmar a intenção de pagamento
        //public string ClientSecret { get; set; }

        //// Usada pelo usuário para poder atualizar a intenção de pagamento (add novos itens, metódo de envio)
        //// atualizar ao invés de criar uma nova
        //// Iterar para verificar itens da cesta de compras e se os preços estão corretos (foreach)
        //public string PaymentIntentId { get; set; }
    }
}
