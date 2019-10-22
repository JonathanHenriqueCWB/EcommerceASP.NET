

using Ecommerce.Models;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.DAL
{
    public class ProdutoDAO
    {

        private readonly Context _context;

        public ProdutoDAO(Context context)
        {
            _context = context;        
        }

        public void CadastrarProduto(Produto p)
        {
            _context.Produtos.Add(p);
            _context.SaveChanges();
        }
        public List<Produto> ListarProdutos()
        {
            return _context.Produtos.ToList();
        }
    }
}
