

using Ecommerce.Models;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.DAL
{
    public class ProdutoDAO
    {
        #region CONFIGURAÇÃO CONTEXTO
        private readonly Context _context;
        public ProdutoDAO(Context context)
        {
            _context = context;        
        }
        #endregion
        #region CADASTRAR
        public bool CadastrarProduto(Produto p)
        {
            _context.Produtos.Add(p);
            _context.SaveChanges();
            return true;
        }
        #endregion
        #region LISTAR
        public List<Produto> ListarProdutos()
        {
            return _context.Produtos.ToList();
        }
        #endregion
        #region REMOVER
        public void Remover(int? id)
        {
            _context.Produtos.Remove(BuscarProdutoId(id));
            _context.SaveChanges();
        }
        #endregion
        #region ALTERAR
        public void Alterar(Produto produto)
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges();
        }
        #endregion
        #region BUSCAR PRODUTO POR ID
        public Produto BuscarProdutoId(int? id)
        {
            return _context.Produtos.Find(id);
        }
        #endregion
    }
}
