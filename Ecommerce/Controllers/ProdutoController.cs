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
            ViewBag.Produtos = _produtoDAO.ListarProdutos();
            return View();
        }
        #endregion
        #region CADASTRAR
        //AÇÃO DE CADATROS GET E POST
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(string txtNome, string txtDescricao, string txtQuantidade, string txtPreco)
        {
            Produto produto = new Produto();
            produto.Nome = txtNome;
            produto.Descricao = txtDescricao;
            produto.Quantidade = Convert.ToInt32(txtQuantidade);
            produto.Preco = Convert.ToDouble(txtPreco);

            _produtoDAO.CadastrarProduto(produto);

            return RedirectToAction("Index");
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

    }
}