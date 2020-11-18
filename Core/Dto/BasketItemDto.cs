using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Dto
{
    public class BasketItemDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string nomeEstacionamento { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Preço precisa ser maior que 0")]
        public decimal Preco { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Quantidade precisa ser de pelo menos 1")]
        public int Quantidade { get; set; }
 
    }
}
