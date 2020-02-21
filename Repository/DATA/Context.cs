using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repository.DATA
{
    public class Context : IdentityDbContext<UsuarioLogado>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
