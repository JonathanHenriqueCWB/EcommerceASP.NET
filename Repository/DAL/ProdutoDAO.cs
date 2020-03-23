using Domain.Contratos;
using Domain.Models;
using Repository.DATA;

namespace Repository.DAL
{

    public class ProdutoDAO : BaseRepositorio<Produto>, IProdutoRepository
    {
        public ProdutoDAO(Context context) : base(context)
        {
        }
    }
}
