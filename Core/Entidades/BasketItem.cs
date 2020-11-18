using System;

namespace Core.Entidades
{
    public class BasketItem
    {
        public int Id { get; set; }

        public string NomeEstacionamento { get; set; }

        public decimal Preco { get; set; }

        public int Quantidade { get; set; }

        public DateTime Data { get; set; } = DateTime.Now;

    }
}