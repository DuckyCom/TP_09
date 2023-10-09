public class Usuario
{

public int idUsuario{get;set;}

public string username{get;set;}

public string contraseña{get;set;}

public string nombre{get;set;}

public string email{get;set;}

public int telefono{get;set;}

public Usuario(string Username, string Contraseña, string Nombre, string Email, int Telefono)
    {
        username = Username;
        contraseña = Contraseña;
        nombre = Nombre;
        email = Email;
        telefono = Telefono;
    }

}