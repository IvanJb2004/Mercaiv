using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Mercaiv.Models.Servicio
{
    public interface IRepositoriopdfCliente
    {
        List<RegistrarModel> pdfCliente(RegistrarModel PdfCliente);
    }
    public class RepositoriopdfCliente : IRepositoriopdfCliente
    {
        private readonly string cnx;
        private readonly IConfiguration configuration;

        public RepositoriopdfCliente(IConfiguration configuration)
        {
            cnx = configuration.GetConnectionString("DefaultConnection");
        }
        public List<RegistrarModel> pdfCliente(RegistrarModel PdfCliente)
        {
            using (IDbConnection db = new SqlConnection(cnx))
            {
                string sqlQuery = "SELECT * FROM Formulario";
                var Cliente = db.Query<RegistrarModel>(sqlQuery).ToList();
                return Cliente;
            }
        }
    }

}
