using System.Data.SqlClient;
using System.Data;
using System.Text.Json;
using Dapper;


namespace Mercaiv.Models.Servicio
{
    public interface IRepositorioCarrito
    {
        void ActualizarItemCarro(int ProductoId, int Cantidad);
        void EliminarItemCarro(int ProductoId);
        List<carroitem> ListarItemsCarro();
        void SelectCarrito(CarritoModel ProductoId, int Cantidad);
    }
    public class RepositorioCarrito : IRepositorioCarrito
    {

        private readonly ProductoSeleccionados _productoSeleccionados;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string cnx;
            public RepositorioCarrito(ProductoSeleccionados productoSeleccionados, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _productoSeleccionados = productoSeleccionados;
            cnx = configuration.GetConnectionString("DefaultConnection");
        }
        private ProductoSeleccionados ObtenerItemSesion()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var cartJson = session.GetString("Carrito");
            return string.IsNullOrEmpty(cartJson)
                ? new ProductoSeleccionados() : JsonSerializer.Deserialize<ProductoSeleccionados>(cartJson);
        }
        public List<carroitem>ListarItemsCarro()
        {
            return ObtenerItemSesion().items;
        }

       
        private void GuardarItemsSesion(ProductoSeleccionados cart)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            session.SetString("Carrito", JsonSerializer.Serialize(cart));
        }
        public void SelectCarrito (CarritoModel ProductoId, int Cantidad)
        {
            var cart = ObtenerItemSesion();

            var existinItem = cart.items.FirstOrDefault(i => i.Producto.idProducto == ProductoId.idProducto);

            if (existinItem != null)
            {
                existinItem.Cantidad += Cantidad;
            }
            else
            {
                cart.items.Add(new carroitem { Producto = ProductoId , Cantidad = Cantidad });
            }
            GuardarItemsSesion(cart);
        }
        public void EliminarItemCarro(int ProductoId)
        {
            var cart = ObtenerItemSesion();
            var item = cart.items.FirstOrDefault(i => i.Producto.idProducto == ProductoId);

            if (item != null)
            {
                cart.items.Remove(item);
                GuardarItemsSesion(cart);
            }
        }
        public decimal ObtenerTotal()
        {
            return _productoSeleccionados.TotalPrecio;
        }

        public void ActualizarItemCarro(int ProductoId, int Cantidad)
        {
            var cart = ObtenerItemSesion();
            var existeItem = cart.items.FirstOrDefault(i => i.Producto.idProducto == ProductoId);
            if (existeItem != null)
            {
                existeItem.Cantidad = Cantidad;
            }
            GuardarItemsSesion(cart);
        }
       

       
    }
}




