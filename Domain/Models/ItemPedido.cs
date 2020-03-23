using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("itemPedidos")]
    public class ItemPedido
    {
        #region ItemPedidoId
        [Key]
        public int ItemPedidoId { get; set; }
        #endregion
        #region Quantidade
        public double Quantidade { get; set; }
        #endregion
        #region Valor
        public decimal Valor { get; set; }
        #endregion

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}
