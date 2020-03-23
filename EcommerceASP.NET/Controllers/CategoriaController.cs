using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.DAL;

namespace EcommerceASP.NET.Controllers
{
    [Authorize]
    public class CategoriaController : Controller
    {
        #region Construtor
        private readonly CategoriaDAO _categoriaDAO;
        public CategoriaController(CategoriaDAO categoriaDAO)
        {
            _categoriaDAO = categoriaDAO;
        }
        #endregion
        #region Index
        public IActionResult Index()
        {
            var list =  _categoriaDAO.FindAll();
            return View(list);
        }
        #endregion
        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _categoriaDAO.Insert(categoria);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        #endregion
    }
}