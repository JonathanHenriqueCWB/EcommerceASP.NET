using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class ItemPedido
    {
        [Key]
        public int ItemPedidoId { get; set; }
        public Produto Produto { get; set; }
        public double Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
