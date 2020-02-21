using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.DATA;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.DAL
{
    public class UsuarioDAO
    {
        private readonly Context _context;
        public UsuarioDAO(Context context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> FindAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task InsertAsync(Usuario usuario)
        {
            Usuario u = await FindByEmailAsync(usuario);
            if (u == null)
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
            }                   
        }

        public async Task<Usuario> FindByEmailAsync(Usuario u)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Email.Equals(u.Email));
        }

    }
}
