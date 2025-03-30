using Dapper;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;

namespace Mercaiv.Models.Servicio
{
    public interface IRepositorioProveedor
    {
        Task<bool> ProveedorModel(ProveedorModel Proveedor);
    }
    public class RepositorioProveedor:IRepositorioProveedor
    {
        private readonly string cnx;

        public RepositorioProveedor(IConfiguration configuration)
        {
            cnx = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> ProveedorModel (ProveedorModel proveedor)
        {
            bool IsInserted = false;

            try
            {
                var connection = new SqlConnection(cnx);
                IsInserted = await connection.ExecuteAsync
                (
                    @"INSERT INTO Proveedor (Codigo,Nombre,Apellido,Nempresa,Telefono,Correo,Direccion) VALUES 
                    (@Codigo,@Nombre,@Apellido,@Nempresa,@Telefono,@Correo,@Direccion)", proveedor) > 0;
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
