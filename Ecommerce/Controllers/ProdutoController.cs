using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.DAL;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class ProdutoController : Controller
    {
        #region COMFIGURAÇÃO CONTEXTO
        private readonly ProdutoDAO _produtoDAO;
        public ProdutoController(ProdutoDAO produtoDAO)
        {
            _produtoDAO = produtoDAO;
        }
        #endregion
        #region INDEX E LISTAR
        //Métodos dos controlers são chamados de actions
        public IActionResult Index()
        {
            return View(_produtoDAO.ListarProdutos());
        }
        #endregion
        #region CADASTRAR
        //AÇÃO DE CADATROS GET E POST
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                if (_produtoDAO.CadastrarProduto(produto))
                {
                    return RedirectToAction("Index");
                }
            }            
            return View();            
        }
        #endregion
        #region REMOVER
        //AÇÃO DE REMOVER
        public IActionResult Remover(int? id)
        {
            if (id != null)
            {
                _produtoDAO.Remover(id);
            }
            else
            {
                //Redirecionar para uma página de erro
            }
            return RedirectToAction("Index");
        }
        #endregion
        #region ALTERAR
        public IActionResult Alterar(int? id)
        {
            return View(_produtoDAO.BuscarProdutoId(id));
        }
        [HttpPost]
        public IActionResult Alterar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _produtoDAO.Alterar(produto);
                return RedirectToAction("Index");
            }
            return View();            
        }
        #endregion

    }
}