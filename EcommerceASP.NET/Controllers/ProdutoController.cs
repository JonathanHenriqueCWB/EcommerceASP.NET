using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.DAL;

namespace EcommerceASP.NET.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoDAO _produtoDAO;
        private readonly CategoriaDAO _categoriaDAO;
        private readonly IHostingEnvironment _hosting; //Imagem
        public ProdutoController(ProdutoDAO produtoDAO, CategoriaDAO categoriaDAO, IHostingEnvironment hosting)
        {
            _produtoDAO = produtoDAO;
            _categoriaDAO = categoriaDAO;
            _hosting = hosting;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _produtoDAO.FindAll();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            //Manda uma viewbag de categoria para view
            ViewBag.Categorias = new SelectList(await _categoriaDAO.FindAllAsync(), "CategoriaId", "Nome");
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

                produto.Categoria = await _categoriaDAO.FindById(drpCategorias);
                Produto p = await _produtoDAO.InsertAsync(produto);
                //Tratar erro de retorno

            }
            return View();
        }
    }
}