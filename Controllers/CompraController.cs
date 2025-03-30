using Mercaiv.Models;
using Mercaiv.Models.Servicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mercaiv.Controllers
{
    public class CompraController : Controller
    {
        private readonly IRepositorioCompra repoCompra;

        public CompraController(IRepositorioCompra repositorioCompra)
        {
            this.repoCompra = repositorioCompra;
        }


        [HttpGet]
        public async Task<IActionResult> ObtenerCompra(string codigo)
        {
            var producto = await repoCompra.ObtenerCompra(codigo);
            if (producto == null)
            {
                return NotFound();
            }
            return Json(producto);
        }

        public IActionResult Compras ()
        {
            return View("~/Views/Compras/Compras.cshtml");
        }

        public IActionResult RecibirDatos([FromBody]List<TablaItem>items)
        {
            return Ok(items);
        }
    }
}
