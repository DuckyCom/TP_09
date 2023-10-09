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

        public IActionResult IngresarUsuarioABD(string username, string contraseña, string nombre, string email, int telefono)
        {
            bool validacion = BD.UsuarioExiste(username);
            if(validacion == true){
                ViewBag.MensajeError = "Ese nombre de usuario ya existe";
                return RedirectToAction("ErrorLogin");
            }else{
            Usuario us = new Usuario(username, contraseña, nombre, email, telefono);
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
        
        public IActionResult NuevaContraseña(string username, string nuevaContraseña, string email) //falta hacer que si el usuario y/o email ingresados no se encuentran lo tiene que redireccionar a ErrorLogin
        {
            Console.WriteLine("NUEVA CONTRASEÑA: " + nuevaContraseña);
            BD.CambiarContraseña(username, nuevaContraseña, email);
            return View("Login");
        }

        // ----- PRIMERA ACCION -----
        // --- donde aparece el usuario y elije si logearse o registrarse ---

        // public IActionResult Index()
        // {
        //     return View();
        // }
        
        // ----- SEGUNDA ACCION -----
        // ---aca es la view donde se registra, en donde dejara sus datos en un form que seran procesador por "IngresarUsuarioABD" ---

        // public IActionResult RegistroUsuario()
        // {
        //     return View();
        // }

        // ----- TERCERA ACCION -----
        // --- Elije registrarse e ingresa su usuario a la BD (sus datos del form serán enviados acá). L<o manda directamente a index, en donde elije si registrarse (lo acaba de hacer) o logearse ---

        // public IActionResult IngresarUsuarioABD(string username, string contraseña)
        // {
        //     ViewBag.Usuario = BD.Login(username, contraseña); [esto estaria mal porque es para registrar el usuario, no para login (en vez de BD.Login hay que poner BD.RegistroUsuario)]
        //     return RedirectToAction("Index");
        // }

        // ----- CUARTA ACCION -----
        // --- Acá el usuario eligió logearse y lo manda a acá ---

        // public IActionResult Login()
        // {
        //     return View();
        // }

        // ----- Quinta ACCION -----
        // --- Acá se verifica si los datos del login estan bien---

        // public IActionResult ResultadosLogin(string username, string contraseña)
        // {
        //     if (ViewBag.Usuario = BD.Login(username, contraseña))
        //      {   
        //    --- Despues de ingresar correctamente sus datos, ya esta en la view Bienvenida ---
        //        return RedirectToAction("Bienvenida");
        //      }
        //    --- Si los datos que ingreso no coinciden con ninguno de BD, lo manda a una view que le dice que esta mal y de esa view hay un button para ir a login ---
        //     else return RedirectToAction("ErrorLogin")
        // }

        // ----- Sexta ACCION -----
        // --- ---

        //  public IActionResult ErrorLogin()
        // {
        //     return View();
        // }
        

       

        
    }
}

