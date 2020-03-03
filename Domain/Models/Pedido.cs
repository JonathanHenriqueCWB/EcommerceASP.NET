using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }
        public Usuario Usuario { get; set; }
        public Endereco Endereco { get; set; }
        public ICollection<ItemPedido> ItemPedidos { get; set; }
    }
}
