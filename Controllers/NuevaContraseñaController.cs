using Mercaiv.Models;
using Mercaiv.Models.Servicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Mercaiv.Controllers
{
    public class NuevaContraseñaController : Controller
    {
        private readonly IRepositorioNuevaContraseña RepoContraseña;

        public NuevaContraseñaController(IRepositorioNuevaContraseña repoContraseña)
        {
            this.RepoContraseña = repoContraseña;
        }

        [HttpPost]
        public async Task<IActionResult> NuevaContraseña(UsuarioModel Nuevo)
        {

            Encryptar clave = new Encryptar();
            Nuevo.Contrasena = clave.Encrypt(Nuevo.Contrasena);
            bool rsp = await RepoContraseña.NuevaContraseña(Nuevo);


            return View();
        }
        public IActionResult NuevaContraseña ()
        {
            return View(); 
        }
    }
}
