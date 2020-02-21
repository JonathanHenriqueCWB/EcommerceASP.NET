using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.DATA;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.DAL
{
    public class CategoriaDAO
    {
        private readonly Context _context;
        public CategoriaDAO(Context context)
        {
            _context = context;
        }

        //Lista todas categorias
        public async Task<List<Categoria>> FindAllAsync()
        {
            return await _context.Categorias.ToListAsync();
        }

        //Cria uma nova categoria
        public async Task InsertAsync(Categoria categoria)
        {
            Categoria c = await FindByName(categoria);
            if (c == null)
            {
                _context.Categorias.Add(categoria);
                await _context.SaveChangesAsync();
            }
        }

        //Procura por nome de uma categoria
        public async Task<Categoria> FindByName(Categoria c)
        {
            return await _context.Categorias.FirstOrDefaultAsync(x => x.Nome.Equals(c.Nome));
        }

        //Buscar pro id
        public async Task<Categoria> FindById(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }

    }
}
