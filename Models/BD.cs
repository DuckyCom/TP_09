using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
//server = . para que se conecte al localhost


namespace TP_09.Models
{
    
public class BD{
    private static string _connectionString = @"Server=.; Database=BDTP09; Trusted_Connection=True;"; 

    public static void RegistroUsuario(Usuario us){
        Console.WriteLine("Entro a BD");
        string sql = "IF NOT EXISTS (SELECT 1 FROM Usuario WHERE username = @pUsername) " +
                 "BEGIN " +
                 "    INSERT INTO Usuario (username, contraseña, nombre, email, telefono) " +
                 "    VALUES (@pUsername, @pContraseña, @pNombre, @pEmail, @pTelefono) " +
                 "END";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(sql, new {pUsername = us.username, pContraseña = us.contraseña, pNombre = us.nombre, pEmail = us.email, pTelefono = us.telefono});
        }
    }

    public static bool UsuarioExiste(string username)
    {
        string sql = "SELECT 1 FROM Usuario WHERE username = @pUsername";

        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            int result = db.QueryFirstOrDefault<int>(sql, new { pUsername = username });
            return result == 1;
        }
    }

    public static Usuario Login(string username, string contraseña){
        Usuario us = null; 
        string sql = "select * from Usuario where username = @pUsername AND contraseña = @pContraseña"; 
        using(SqlConnection db = new SqlConnection(_connectionString)){
            us = db.QueryFirstOrDefault<Usuario>(sql, new {pUsername = username, pContraseña = contraseña});
        }
        return us; 
    }

    public static void CambiarContraseña(string username, string nuevaContraseña, string email){
        string sql = "Update Usuario set contraseña = @pNuevaContraseña where username = @pUsername AND email = @pEmail";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(sql, new {pNuevaContraseña = nuevaContraseña, pUsername = username, pEmail = email});
        }
    }
}
}