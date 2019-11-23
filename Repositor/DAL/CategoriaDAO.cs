using Domain.Models;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.DAL
{
    public class CategoriaDAO : IRepository<Categoria>
    {
        #region Injeção de dependencias
        private readonly Context _context;
        public CategoriaDAO(Context context)
        {
            _context = context;
        }
        #endregion

        public Categoria BuscarPorId(int? id)
        {
            return _context.Categorias.Find(id);
        }

        public bool Cadastrar(Categoria objeto)
        {
            if (BuscarPorNome(objeto) == null)
            {
                _context.Categorias.Add(objeto);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Categoria> Listar()
        {
            return _context.Categorias.ToList();
        }

        public Categoria BuscarPorNome(Categoria objeto)
        {
            return _context.Categorias.FirstOrDefault(x => x.Nome.Equals(objeto.Nome));
        }
    }
}
