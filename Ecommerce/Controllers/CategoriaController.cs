using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.DAL;

namespace Ecommerce.Controllers
{
    public class CategoriaController : Controller
    {
        #region Injeção de dependências e contrutor
        private readonly CategoriaDAO _categoriaDAO;
        public CategoriaController(CategoriaDAO categoriaDAO)
        {
            _categoriaDAO = categoriaDAO;
        }
        #endregion
        #region Index Listar
        public IActionResult Index()
        {
            return View(_categoriaDAO.Listar());
        }
        #endregion
        #region CADASTRAR CATEGORIA
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Categoria categoria )
        {
            if (ModelState.IsValid)
            {
                if (_categoriaDAO.Cadastrar(categoria))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Essa categoria já existe");
                }
            }
            return View();
        }
        #endregion
    }
}