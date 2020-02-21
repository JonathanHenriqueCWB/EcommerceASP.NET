using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.DAL;
using Microsoft.AspNetCore.Identity;

namespace EcommerceASP.NET.Controllers
{
    public class UsuarioController : Controller
    {
        #region Construtor
        private readonly UsuarioDAO _usuarioDAO;
        private readonly UserManager<UsuarioLogado> _userManager;
        private readonly SignInManager<UsuarioLogado> _signInManager;
        public UsuarioController(UsuarioDAO usuarioDAO, UserManager<UsuarioLogado> userManager, SignInManager<UsuarioLogado> signInManager)
        {
            _usuarioDAO = usuarioDAO;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        #endregion
        #region Index
        public async Task<IActionResult> Index()
        {
            var list = await _usuarioDAO.FindAllAsync();
            return View(list);
        }
        #endregion
        #region Create
        /*TRANSFORMAR E ASINCRONO*/
        public IActionResult Create()
        {
            Usuario u = new Usuario();
            if (TempData["Endereco"] != null)
            {
                string resultado = TempData["Endereco"].ToString();
                Endereco endereco = JsonConvert.DeserializeObject<Endereco>(resultado);
                u.Endereco = endereco;
            }
            return View(u);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                //Criar um objeto do UsuarioLogado e passar obrigatoriamente o Email e UserName
                UsuarioLogado usuarioLogado = new UsuarioLogado
                {
                    Email = usuario.Email,
                    UserName = usuario.Email
                };

                //Cadastra o usuário na tabela do Identity
                IdentityResult result = await _userManager.CreateAsync(usuarioLogado, usuario.Senha);

                //Testando resultado do cadastro
                if (result.Succeeded)
                {
                    //Logar o usuário no sistema
                    await _signInManager.SignInAsync(usuarioLogado, isPersistent: false);

                    //Cadastra usuario na tabela de usuario normal
                    await _usuarioDAO.InsertAsync(usuario);
                    return RedirectToAction(nameof(Index));
                }                
            }            
            return View(usuario);
        }
        #endregion
        #region Buscar Cep
        /*TRANSFORMAR E ASINCRONO*/
        public IActionResult BuscarCep(Usuario usuario)
        {
            string url = "https://viacep.com.br/ws/" + usuario.Endereco.Cep + "/json/";
            WebClient client = new WebClient();
            TempData["Endereco"] = client.DownloadString(url);

            return RedirectToAction(nameof(Create));
        }
        #endregion
        #region Login e Logout
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Usuario usuario)
        {
            var result = await _signInManager.PasswordSignInAsync(usuario.Email, usuario.Senha, true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                //Mudar o redirecionamento para return RedirectToAction("Index" , "Produtos")
                return RedirectToAction("Index" , "Produto");
            }
            return View();
        }
        
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}