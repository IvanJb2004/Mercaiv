using Mercaiv.Models;
using Mercaiv.Models.Servicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mercaiv.Controllers
{
    public class ProveedorController : Controller
    {
        private readonly IRepositorioProveedor RepoProvedor;

        public ProveedorController(IRepositorioProveedor repoProvedor)
        {
           this.RepoProvedor = repoProvedor;
        }

        public IActionResult Proveedor(ProveedorModel proveedor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(proveedor);
                }
                RepoProvedor.ProveedorModel(proveedor);
            }
            catch (Exception ex)
            {

            }
            return View();
        }
    }
}
