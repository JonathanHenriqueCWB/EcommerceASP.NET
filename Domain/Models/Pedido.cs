using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Pedidos")]
    public class Pedido
    {
        #region PedidoId
        [Key]
        public int PedidoId { get; set; }
        #endregion
        #region Data Pedido
        public DateTime DataPedido { get; set; }
        #endregion
        #region Data Previsao Entrega
        public DateTime DataPrevisaoEntrega { get; set; }
        #endregion

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public ICollection<ItemPedido> ItemPedidos { get; set; }
    }
}
