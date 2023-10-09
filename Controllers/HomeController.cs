using Microsoft.AspNetCore.Mvc;
using TP_09.Models;
//cambiarle despues nombre a AccountController. 
//cambiarle tambiene l nombre a la carpeta donde estan los .cshtml (de "Home" a "Account")
namespace TP_09.Controllers
{
    public class HomeController : Controller
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
                return RedirectToAction("ErrorLogin");
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
            bool usuarioEncontrado = false; 
            if(ViewBag.Usuario != null){
                usuarioEncontrado = true;
            }
            if(usuarioEncontrado == true)
            {   
            //--- Despues de ingresar correctamente sus datos, ya esta en la view Bienvenida ---
               return View("Bienvenida");
            }
            // --- Si los datos que ingreso no coinciden con ninguno de BD, lo manda a una view que le dice que esta mal y de esa view hay un button para ir a login ---
            else return RedirectToAction("ErrorLogin");
        }
        public IActionResult ErrorLogin(){
            return View();
        }
        
        public IActionResult NuevaContraseña(string username, string nuevaContraseña, string telefono) //falta hacer que si el usuario y/o email ingresados no se encuentran lo tiene que redireccionar a ErrorLogin
        { bool validacion = BD.UsuarioExiste(username);
            if(validacion == false){
                ViewBag.MensajeError = "Ese nombre de usuario no existe";
                return RedirectToAction("ErrorLogin");
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

