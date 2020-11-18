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

        public string ClientSecret { get; set; }

        public string PaymentIntentId { get; set; }
    }
}
