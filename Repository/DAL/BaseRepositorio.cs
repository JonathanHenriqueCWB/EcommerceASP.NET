using Domain.Contratos;
using Repository.DATA;
using System.Collections.Generic;
using System.Linq;

namespace Repository.DAL
{
    public class BaseRepositorio<Objeto> : IBaseRepository<Objeto> where Objeto : class
    {
        protected readonly Context Context;
        public BaseRepositorio(Context context)
        {
            Context = context;
        }

        public IEnumerable<Objeto> FindAll()
        {
            return Context.Set<Objeto>().ToList();
        }

        public Objeto FindById(int id)
        {
            return Context.Set<Objeto>().Find(id);
        }

        public void Insert(Objeto objeto)
        {
            Context.Set<Objeto>().Add(objeto);
            Context.SaveChanges();
        }

        public void Remove(int id)
        {
            var objeto = FindById(id);
            Context.Set<Objeto>().Remove(objeto);
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
