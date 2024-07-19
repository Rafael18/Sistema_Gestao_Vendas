using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;
using SistemaVendas.Uteis;
using System.Diagnostics;

namespace SistemaVendas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Menu()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login(int? id)
        {
            //Para realizar Logout
            if (id != null)
            {
                if (id == 0)
                {
                    HttpContext.Session.SetString("IdUsuarioLogado", string.Empty);
                    HttpContext.Session.SetString("NomeUsuarioLogado", string.Empty);
                }

            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                bool loginOk = login.validarLogin();

                if (loginOk)
                {
                    HttpContext.Session.SetString("IdUsuarioLogado", login.Id);
                    HttpContext.Session.SetString("NomeUsuarioLogado", login.Nome);
                    return RedirectToAction("Menu", "Home");
                }
                else
                {
                    TempData["ErrorLogin"] = "E-mail ou senha inválidos";
                }
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
