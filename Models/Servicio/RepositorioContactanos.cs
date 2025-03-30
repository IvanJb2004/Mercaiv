using Dapper;
using System.Data.SqlClient;
using Mercaiv.Models;

namespace Mercaiv.Models.Servicio
{
    public interface IRepositorioContactanos
    {
        Task<bool> InfoContactoModel(InfoContactoModel contacto);
    }
    public class RepositorioContactanos:IRepositorioContactanos
    {
        private readonly string cnx;

        public RepositorioContactanos(IConfiguration configuration)
        {
            cnx = configuration.GetConnectionString("DefaultConnection");
        }


        
        public async Task<bool> InfoContactoModel(InfoContactoModel contacto)
        {
           
            bool IsInserted=false;

            try
            {
              var connection = new SqlConnection(cnx);
              IsInserted = await connection.ExecuteAsync
                  (
                  @"INSERT INTO Contactanos (Nombre,Correo,Mensaje) VALUES (@Nombre,@Correo,@Mensaje)", contacto) > 0;
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
