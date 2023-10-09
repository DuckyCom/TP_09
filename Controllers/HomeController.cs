using Microsoft.AspNetCore.Mvc;
using TP_09.Models;
//cambiarle despues nombre a AccountController. 
//cambiarle tambiene l nombre a la carpeta donde estan los .cshtml (de "Home" a "Account")
namespace TP_09.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegistroUsuario()
        {
            return View();
        }
         
        public IActionResult OlvideMiContraseña(){
            
            return View();
        }

        public IActionResult IngresarUsuarioABD(Usuario us)
        {
            bool validacion = BD.UsuarioExiste(us.username);
            if(validacion == true){
             ViewBag.MensajeError = "Ese nombre de usuario ya existe";
                return View("ErrorLogin");
            }
            else{
            ViewBag.Usuario = us;
            BD.RegistroUsuario(us);
            return View("Bienvenida");
            }
        }

        public IActionResult Login(){
            return View("Login");
        }

        public IActionResult ResultadoLogin(string username, string contraseña)
        {
            ViewBag.Usuario = BD.Login(username, contraseña);
            if(ViewBag.Usuario != null){
                return View("Bienvenida");
            }
            else{
                //esto no ocurre, tira un error (si te equivocas en contraseña Y/o nombre)
                //ViewBag.MensajeError = "Nombre de usuario o contraseña inexistente";
                return View("ErrorLogin");
            }
        } 
        
        public IActionResult NuevaContraseña(string username, string nuevaContraseña, string telefono) 
        { 
            bool validacion = BD.UsuarioExiste(username);
            if(validacion == false){
                ViewBag.MensajeError = "Ese nombre de usuario no existe";
                return View("ErrorLogin");
            }
            else
            {
            Console.WriteLine("NUEVA CONTRASEÑA: " + nuevaContraseña);
            BD.CambiarContraseña(username, nuevaContraseña, telefono);
            return View("Login");
            }
        }

        
    }
}

