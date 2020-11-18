using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto
{
    public class CestaClienteDto
    {
        public string Id { get; set; }

        public List<BasketItem> ItensCestaCliente { get; set; }

        public string ClientSecret { get; set; }

        public string PaymentIntentId { get; set; }
    }
}
