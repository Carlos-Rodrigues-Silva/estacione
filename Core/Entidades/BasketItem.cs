using System;

namespace Core.Entidades
{
    /// <summary>
    /// Representa um item da cesta de compras do cliente (ou seja: uma vaga)
    /// </summary>
    public class BasketItem
    {
        public int Id { get; set; }

        public string NomeEstacionamento { get; set; }

        public decimal Preco { get; set; }

        public int Quantidade { get; set; }

        //public string FotoUrl { get; set; }

        public DateTime Data { get; set; } = DateTime.Now;

    }
}