using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
    class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.ProdutoId);


            builder.Property(p => p.ProdutoId).IsRequired();
            builder.Property(p => p.CriadoEm).IsRequired();
            builder.Property(p => p.Imagem).IsRequired();
            builder.Property(p => p.Nome).IsRequired();
            builder.Property(p => p.Preco).IsRequired();
            builder.Property(p => p.Quantidade).IsRequired();

            builder.HasOne(p => p.Categoria);
        }
    }
}
