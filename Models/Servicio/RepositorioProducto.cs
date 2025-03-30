using Dapper;
using System.Data.SqlClient;
using Mercaiv.Models;
using System.Data;

namespace Mercaiv.Models.Servicio
{
    public interface IRepositorioProducto
    {
        Task<bool> InsertarProductoModel(InsertarProductoModel ccc);
        InsertarProductoModel SeleccionarProducto(int idProducto);
        CarritoModel SelectCarrito(int ProductoId, int Cantidad);
    }
    public class RepositorioProducto : IRepositorioProducto
    {
        private readonly string cnx;

        public RepositorioProducto(IConfiguration configuration)
        {
            cnx = configuration.GetConnectionString("DefaultConnection");
        }



        public async Task<bool> InsertarProductoModel(InsertarProductoModel ccc)
        {

            bool IsInserted = false;

            try
            {
                var connection = new SqlConnection(cnx);
                IsInserted = await connection.ExecuteAsync
                    (
                    @"INSERT INTO InsertarProducto(Codigo,Nombre,Descripcion,PrecioV,Unidades,Estado,urlimagen,Color,Marca,Modelo) 
                        VALUES (@Codigo,@Nombre,@Descripcion,@PrecioV,@Unidades,@Estado,@urlimagen,@Color,@Marca,@Modelo)", ccc) > 0;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return IsInserted;
        }
        public InsertarProductoModel SeleccionarProducto(int idProducto)
        {
            using (IDbConnection db = new SqlConnection(cnx))
            {
                string sqlQuery = "SELECT * FROM  InsertarProducto WHERE idProducto = @idProducto";

                InsertarProductoModel ccc =
                db.QuerySingleOrDefault <InsertarProductoModel>(sqlQuery, new {idProducto});
                return ccc;
            }

        }
        public CarritoModel SelectCarrito(int ProductoId,int Cantidad)
        {
            using (IDbConnection db = new SqlConnection(cnx))
            {
                string sqlQuery = "SELECT * FROM  InsertarProducto WHERE idProducto = @ProductoId";

                CarritoModel ccc =
                db.QuerySingleOrDefault<CarritoModel>(sqlQuery, new { ProductoId,Cantidad });
                return ccc;
            }

        }

    }
}
        
    



