using Domain.Contratos;
using Domain.Models;
using Repository.DATA;

namespace Repository.DAL
{
    public class CategoriaDAO :BaseRepositorio<Categoria>, ICategoriaRepository
    {
        public CategoriaDAO(Context context) : base(context)
        {
        }
    }
}
