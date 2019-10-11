

using Ecommerce.Models;

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
    }
}
