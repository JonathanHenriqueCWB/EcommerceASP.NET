﻿using System;
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
        public async Task<IActionResult> Index()
        {
            var list = await _categoriaDAO.FindAllAsync();
            return View(list);
        }
        #endregion
        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                await _categoriaDAO.InsertAsync(categoria);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        #endregion
    }
}