using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
    public class ItemPedidoConfiguration : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.HasKey(ip => ip.ItemPedidoId);

            builder.Property(ip => ip.ItemPedidoId).IsRequired();
            builder.Property(ip => ip.Produto).IsRequired();
            builder.Property(ip => ip.Quantidade).IsRequired();
            builder.Property(ip => ip.Valor).IsRequired();

        }
    }
}
