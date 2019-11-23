using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Ecommerce.DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.DAL;

namespace Ecommerce.Controllers
{
    public class ProdutoController : Controller
    {
        #region COMFIGURAÇÃO CONTEXTO
        private readonly ProdutoDAO _produtoDAO;
        private readonly CategoriaDAO _categoriaDAO;
        private readonly IHostingEnvironment _hosting;
        public ProdutoController(ProdutoDAO produtoDAO, CategoriaDAO categoriaDAO, IHostingEnvironment hosting)
        {
            _produtoDAO = produtoDAO;
            _categoriaDAO = categoriaDAO;
            _hosting = hosting;
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
            ViewBag.Categorias = new SelectList(_categoriaDAO.Listar(), "CategoriaId", "Nome");
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Produto produto, int drpCategorias, IFormFile fupImagem)
        {
            //Recupera do banco as categorias para cadastro de produto   
            ViewBag.Categorias = new SelectList(_categoriaDAO.Listar(), "CategoriaId", "Nome");

            if (ModelState.IsValid)
            {
                //Códito referente a imagem do produto (salvara somente o link no DB)
                if (fupImagem != null)
                {
                    string arquivo = Guid.NewGuid().ToString() + Path.GetExtension(fupImagem.FileName);
                    string caminho = Path.Combine(_hosting.WebRootPath, "images", arquivo);
                    fupImagem.CopyTo(new FileStream(caminho, FileMode.Create));
                    produto.Imagem = arquivo;
                }
                else
                {
                    produto.Imagem = "semimagem.jpg";
                }

                //Sanvando Categoria de um produto
                produto.Categoria = _categoriaDAO.BuscarPorId(drpCategorias);
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