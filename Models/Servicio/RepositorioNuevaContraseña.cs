using Dapper;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;

namespace Mercaiv.Models.Servicio
{
    public interface IRepositorioNuevaContraseña
    {
        Task<bool> NuevaContraseña(UsuarioModel Nuevo);
    }
    public class RepositorioNuevaContraseña:IRepositorioNuevaContraseña
    {
        private readonly string cnx;

        public RepositorioNuevaContraseña(IConfiguration configuration)
        {

            cnx = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> NuevaContraseña(UsuarioModel Nuevo)
        { 
             bool IsInserted = false;

            try
            {
                var connection = new SqlConnection(cnx);
                IsInserted = await connection.ExecuteAsync
                    (
                          @"UPDATE Formulario SET Contrasena=@Contrasena WHERE Nombre=@Nombre",Nuevo)>0;
            }
            catch
            (Exception ex)
            {
                string msg = ex.Message;
            }

            return IsInserted;
            }
    }
}
