using Mercaiv.Servicio;
using Mercaiv.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mercaiv.Models.Servicio;

namespace Mercaiv.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IRepositorioProducto repoProducto;

        public ProductosController(IRepositorioProducto repoProducto)
        {
            this.repoProducto = repoProducto;
        }

        public async Task<IActionResult> ProductoAsync(InsertarProductoModel ccc)
        {


            try
            {

                // if (!ModelState.IsValid)
                //{
                //  return View(ccc);
                //}
                if (ccc.Imagen != null && ccc.Imagen.Length > 0)
                {
                    var extension = Path.GetExtension(ccc.Imagen.FileName);
                    var NuevoNombre = Guid.NewGuid().ToString() + extension;
                    var FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Inventario", NuevoNombre);
                    using (var stream = new FileStream(FilePath, FileMode.Create))
                    {
                        await ccc.Imagen.CopyToAsync(stream);
                    }
                    ccc.urlimagen = "/inventario/"+ NuevoNombre;
                }


                TempData["SucessMessage"] = "El Registro Fue Exitoso";
                repoProducto.InsertarProductoModel(ccc);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }


            return View();
        }


        [HttpGet]
        public IActionResult Producto()
        {
            return View();
        
        }

        [HttpGet]
        public JsonResult SeleccionarProducto(int id)
        {

            InsertarProductoModel detalle = repoProducto.SeleccionarProducto(id);
            detalle.Color = detalle.Color == null ? "N/A" : detalle.Color;
            detalle.Modelo = detalle.Modelo == null ? "N/A" : detalle.Modelo;
            detalle.Marca = detalle.Marca == null? "N/A:":detalle.Marca;
            
            return Json(detalle);

        }
    
    }
}


        
           


  