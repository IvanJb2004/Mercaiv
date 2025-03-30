using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Mercaiv.Models.Servicio
{
    public interface IRepositoriopdfInventario
    {
        List<InsertarProductoModel> pdfInventario(InsertarProductoModel PdfInventario);
    }
    public class RepositoriopdfInventario:IRepositoriopdfInventario
    {
        private readonly string cnx;
        private readonly IConfiguration configuration;
            
        public RepositoriopdfInventario(IConfiguration configuration)
        {
            cnx = configuration.GetConnectionString("DefaultConnection");
        }
        public List<InsertarProductoModel>pdfInventario(InsertarProductoModel PdfInventario)
        {
            using(IDbConnection db = new SqlConnection(cnx))
            {
                string sqlQuery = "SELECT * FROM InsertarProducto";
                var ProductoInventario = db.Query<InsertarProductoModel>(sqlQuery).ToList();
                return ProductoInventario;
            }
        }
    }
    
}
