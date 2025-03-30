using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Mercaiv.Models.Servicio
{


    public interface IRepositorioHome
    {
        IEnumerable<InsertarProductoModel> ListarProductos();
    }
    public class RepositorioHome:IRepositorioHome
        {
            private readonly string cnx;
            public RepositorioHome(IConfiguration configuration)
            {
                cnx = configuration.GetConnectionString("DefaultConnection");
            }
        public IEnumerable<InsertarProductoModel> ListarProductos()
        {
                using(IDbConnection db = new SqlConnection(cnx))
                {
                    string sqlQuery = "SELECT * FROM  InsertarProducto";
                     var Productos = db.Query<InsertarProductoModel>(sqlQuery).ToList();
                    return Productos;
                }
            }


        }
    }

