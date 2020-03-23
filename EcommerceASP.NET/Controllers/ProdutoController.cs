using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Domain.Models;
using EcommerceASP.NET.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.DAL;

namespace EcommerceASP.NET.Controllers
{
    [Authorize]
    public class ProdutoController : Controller
    {
        #region Construtor
        private readonly ProdutoDAO _produtoDAO;
        private readonly CategoriaDAO _categoriaDAO;
        private readonly IHostingEnvironment _hosting; //Imagem
        public ProdutoController(ProdutoDAO produtoDAO, CategoriaDAO categoriaDAO, IHostingEnvironment hosting)
        {
            _produtoDAO = produtoDAO;
            _categoriaDAO = categoriaDAO;
            _hosting = hosting;
        }
        #endregion
        #region Index
        public async Task<IActionResult> Index()
        {
            var list = await _produtoDAO.FindAll();
            return View(list);
        }
        #endregion
        #region Create
        public IActionResult Create()
        {
            //Manda uma viewbag de categoria para view
            ViewBag.Categorias = new SelectList(_categoriaDAO.FindAll(), "CategoriaId", "Nome");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Produto produto, int drpCategorias, IFormFile fupImagem)
        {
            if (ModelState.IsValid)
            {
                if (fupImagem != null)
                {
                    //Renomeia o arquivo com guid vindo da view
                    string arquivo = Guid.NewGuid().ToString() + Path.GetExtension(fupImagem.FileName);
                    string caminho = Path.Combine(_hosting.WebRootPath, "images", arquivo);
                    fupImagem.CopyTo( new FileStream(caminho, FileMode.Create));
                    produto.Imagem = arquivo;
                }
                else
                {
                    produto.Imagem = "semimagem.jpg";
                }

                produto.Categoria = _categoriaDAO.FindById(drpCategorias);
                Produto p = await _produtoDAO.InsertAsync(produto);
                //Tratar erro de retorno

            }
            return View();
        }
        #endregion
        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            //Por id ser opcional deve incluir o value junto
            var obj = await _produtoDAO.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _produtoDAO.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        /*
         * INSTANCIA UMA PÁGIA DO ErrorViewModel PASSA MENSAGEM DO PARAMETRO
         * DA CHAMADA E RETORNA A VIEW DE ERRO COM MSG
        */
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}