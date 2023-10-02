using Microsoft.AspNetCore.Mvc;
using TP_09.Models;

namespace TP_09.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegistroUsuario(Usuario us)
        {
            Console.WriteLine("Entro al controller");
            BD.RegistroUsuario(us);
            return View("RegistroUsuario");
        }

        public IActionResult Login(string username, string contraseña)
        {
            ViewBag.Usuario = BD.Login(username, contraseña);
            return View("IndexPostLogin");
        }

        public IActionResult OlvideMiContraseña(string username, string nuevaContraseña)
        {
            BD.CambiarContraseña(username, nuevaContraseña);
            return RedirectToAction("Login");
        }
    }
}

