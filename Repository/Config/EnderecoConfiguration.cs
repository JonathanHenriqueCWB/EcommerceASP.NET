using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.EnderecoId);

            builder.Property(e => e.EnderecoId).IsRequired();
            builder.Property(e => e.Bairro).IsRequired();
            builder.Property(e => e.Cep).IsRequired();
            builder.Property(e => e.Localidade).IsRequired();
            builder.Property(e => e.Logradouro).IsRequired();
            builder.Property(e => e.Uf).IsRequired();
        }
    }
}
