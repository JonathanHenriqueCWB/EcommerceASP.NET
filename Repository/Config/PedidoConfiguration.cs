using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
    class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.PedidoId);

            builder.Property(p => p.PedidoId).IsRequired();
            builder.Property(p => p.ItemPedidos).IsRequired();
            builder.Property(p => p.DataPedido).IsRequired();
            builder.Property(p => p.DataPrevisaoEntrega).IsRequired();
        }
    }
}
