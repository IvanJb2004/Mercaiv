using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Mercaiv.Models.Servicio
{
    public interface IRepositoriopdfContactanos
    {
        List<InfoContactoModel> pdfContactanos(InfoContactoModel PdfContactanos);
    }
    public class RepositoriopdfContactanos : IRepositoriopdfContactanos
    {
        private readonly string cnx;
        private readonly IConfiguration configuration;

        public RepositoriopdfContactanos(IConfiguration configuration)
        {
            cnx = configuration.GetConnectionString("DefaultConnection");
        }
        public List<InfoContactoModel> pdfContactanos(InfoContactoModel PdfContactanos)
        {
            using (IDbConnection db = new SqlConnection(cnx))
            {
                string sqlQuery = "SELECT * FROM Contactanos";
                var ProductoInventario = db.Query<InfoContactoModel>(sqlQuery).ToList();
                return ProductoInventario;
            }
        }
    }

}
