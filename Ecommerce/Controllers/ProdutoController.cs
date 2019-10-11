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
        private readonly ProdutoDAO _produtoDAO;
        public ProdutoController(ProdutoDAO produtoDAO)
        {
            _produtoDAO = produtoDAO;
        }

        //Métodos dos controlers são chamados de actions
        public IActionResult Index()
        {
            return View();
        }

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

            return View();
        }
    }
}