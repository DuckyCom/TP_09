using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
//server = . para que se conecte al localhost


namespace TP_09.Models
{
    
public class BD{
    private static string _connectionString = @"Server=.; Database=BD; Trusted_Connection=True;"; 

    public static void RegistroUsuario(Usuario us){
        Console.WriteLine("Entro a BD");
        string sql = "Insert into Usuario (username, contraseña, nombre, email, telefono) values (@pUsername, @pContraseña, @pNombre, @pEmail, @pTelefono)";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(sql, new {pUsername = us.username, pContraseña = us.contraseña, pNombre = us.nombre, pEmail = us.email, pTelefono = us.telefono});
        }
    }

    public static Usuario Login(string username, string contraseña){ //falta escribir el caso en el que este mal el usuario o contraseña. 
        Usuario us = null; 
        string sql = "select * from Usuario where username = @pUsername AND contraseña = @pContraseña"; //el if anda
        using(SqlConnection db = new SqlConnection(_connectionString)){
            us = db.QueryFirstOrDefault<Usuario>(sql, new {pUsername = username, pContraseña = contraseña});
        }
        return us; 
    }

    public static void CambiarContraseña(string username, string nuevaContraseña){
        string sql = "Update Usuario set contraseña = @pNuevaContraseña where username = @pUsername";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(sql, new {pNuevaContraseña = nuevaContraseña, pUsername = username});
        }
    }
}
}