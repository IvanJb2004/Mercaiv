using Dapper;
using Mercaiv.Models;
using System.Data.SqlClient;

namespace Mercaiv.Servicio
{
    public interface IRepositorioUsuario
    {
        Task<bool> RegistrarModel(RegistrarModel datos);
        Task<bool> ValidarUsuario(UsuarioModel informacion);
       
    }
        public class RepositorioUsuario : IRepositorioUsuario
        {
            private readonly string cnx;

            public RepositorioUsuario(IConfiguration configuration)
            {
                cnx = configuration.GetConnectionString("DefaultConnection");
            }

            public async Task<bool> RegistrarModel(RegistrarModel datos)
            {
                bool isInserted = false;
                try
                {
                    var connection = new SqlConnection(cnx);
                    isInserted = await connection.ExecuteAsync(
                        @"INSERT INTO Formulario(Identificacion, Nombre,Apellido,Genero,Fecha,Correo,Contrasena)
                VALUES(@Identificacion,@Nombre,@Apellido,@Genero,@Fecha,@Correo,@Contrasena)", datos) > 0;
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
                return isInserted;
            }

            public async Task<bool> ValidarUsuario(UsuarioModel informacion)
            {
                using var connection = new SqlConnection(cnx);
                string query = @"SELECT COUNT(1) FROM Formulario WHERE Nombre=@Nombre AND Contrasena=@Contrasena";
                bool usuarioExiste = await connection.ExecuteScalarAsync<int>(query, new { informacion.Nombre, informacion.Contrasena }) > 0;
                return usuarioExiste;
            }

            
        }
} 

    
