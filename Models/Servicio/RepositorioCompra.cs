using Dapper;
using System.Data.SqlClient;
using static Mercaiv.Models.CarritoModel;
using static Mercaiv.Models.Servicio.IRepositorioProducto;

namespace Mercaiv.Models.Servicio
{
    public interface IRepositorioCompra
    {
        Task BorrarProducto(int id);
        Task<InsertarProductoModel> ObtenerCompra(string codigo);
    }
    public class RepositorioCompra:IRepositorioCompra
    {
        private readonly string cnx;
        public RepositorioCompra(IConfiguration configuration)
        {
            cnx = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task BorrarProducto(int id)
        {
            using var connection = new SqlConnection(cnx);
            var query = " DELETE FROM InsertarProducto WHERE codigo=@codigo";
            await connection.ExecuteAsync(query,new {Codigo = id});
        }
        public async Task<InsertarProductoModel> ObtenerCompra(string codigo)
        {
            try
            {
                using var connection = new SqlConnection(cnx);
                var query = "SELECT Codigo,Nombre,Preciov,Unidades FROM InsertarProducto WHERE Codigo =@Codigo";
                return await connection.QueryFirstOrDefaultAsync<InsertarProductoModel>(query, new { Codigo = codigo });
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
            }
            return null;
            

        }
    }

}
