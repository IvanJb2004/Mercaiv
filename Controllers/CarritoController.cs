using Mercaiv.Models;
using Mercaiv.Models.Servicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mercaiv.Controllers
{
    public class CarritoController : Controller
    {
        private readonly IRepositorioCarrito _CarritoServicio;
        private readonly IRepositorioProducto repoProducto;
        public CarritoController(IRepositorioCarrito CarritoServicio, IRepositorioProducto repositorioProducto)
        {
            _CarritoServicio = CarritoServicio;
            repoProducto = repositorioProducto;
        }
        public IActionResult SelectCarrito(CarritoModel ProductoId, int Cantidad)
        {
          

            if (ProductoId != null )
            {
               _CarritoServicio.SelectCarrito(ProductoId, Cantidad);
            }
            var carritoItems = _CarritoServicio.ListarItemsCarro();
            return View("carrito",carritoItems);
        }
        public IActionResult Eliminar(int ProductoId)
        {
            _CarritoServicio.EliminarItemCarro(ProductoId);
            var carritoItems = _CarritoServicio.ListarItemsCarro();
            return View("Carrito", carritoItems);
        }
        public IActionResult ActualizarItem(int ProductoId, int Cantidad)
        {
            if (Cantidad < 1)
            {
                return BadRequest("La cantidad debe ser al menos 1.");
            }
            _CarritoServicio.ActualizarItemCarro(ProductoId, Cantidad);
            var carritoItems = _CarritoServicio.ListarItemsCarro();
            return View("Carrito", carritoItems);



        }
        public IActionResult Carrito (int ProductoId,int Cantidad)
        { 
            var conectar= repoProducto.SelectCarrito(ProductoId,Cantidad);


            if (conectar != null)
            {
                _CarritoServicio.SelectCarrito(conectar, Cantidad);
            }
            var carritoItems = _CarritoServicio.ListarItemsCarro();
            return View( carritoItems);
         
        }
    }

}
