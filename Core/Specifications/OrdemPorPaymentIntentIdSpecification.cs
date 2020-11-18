using Core.Entidades.OrdemAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
    public class OrdemPorPaymentIntentIdSpecification : BaseSpecification<Ordem>
    {
        public OrdemPorPaymentIntentIdSpecification(string paymentIntentId) : base(o => o.PaymentIntentId == paymentIntentId)
        {

        }
    }
}
