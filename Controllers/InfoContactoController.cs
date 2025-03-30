using Mercaiv.Servicio;
using Mercaiv.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mercaiv.Models.Servicio;

namespace Mercaiv.Controllers
{
    public class InfoContactoController : Controller
    {
        private readonly IRepositorioContactanos repoContactanos;

        public InfoContactoController(IRepositorioContactanos repoContactanos)
        {
            this.repoContactanos = repoContactanos;
        }

        public IActionResult Contactanos(InfoContactoModel contacto) 
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(contacto);
                }
                repoContactanos.InfoContactoModel(contacto);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public IActionResult RecuperarContraseña()
        {
            return View();
        }

    }
}
