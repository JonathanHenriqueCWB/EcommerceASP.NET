using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.DATA;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DAL
{

    public class ProdutoDAO
    {
        private readonly Context _context;
        public ProdutoDAO(Context context)
        {
            _context = context;
        }

        public async Task<Produto> InsertAsync(Produto produto)
        {
            Produto p = await FindByName(produto);
            if (p == null)
            {
                _context.Produtos.Add(produto);
                await _context.SaveChangesAsync();
                return produto;
            }
            return null;
        }

        public async Task<List<Produto>> FindAll()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto> FindByName(Produto p)
        {
            return await _context.Produtos.FirstOrDefaultAsync(x => x.Nome.Equals(p.Nome));
        }

        public async Task<Produto> FindByIdAsync(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Produtos.FindAsync(id);
            _context.Produtos.Remove(obj);
            await _context.SaveChangesAsync();
        }
    }
}
