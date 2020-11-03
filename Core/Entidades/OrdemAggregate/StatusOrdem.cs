using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Core.Entidades.OrdemAggregate
{
    public enum  StatusOrdem
    {
        [EnumMember(Value = "Pagamento Pendete")]
        PagamentoPendente,

        [EnumMember(Value = "Pagamento Recebido")]
        PagamentoRecebido,

        [EnumMember(Value = "Pagamento Recusado")]
        PagamentoRecusado
    }
}
