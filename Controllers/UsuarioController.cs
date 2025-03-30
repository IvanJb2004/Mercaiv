using Mercaiv.Models;
using Mercaiv.Models.Servicio;
using Mercaiv.Servicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mercaiv.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IRepositorioUsuario repousuario;
        private readonly IRepositorioHome RepoHome;
        public UsuarioController(IRepositorioUsuario repousuario, IRepositorioHome RepoHome)
        {
            this.repousuario = repousuario;
            this.RepoHome = RepoHome;
        }

        public IActionResult login(UsuarioModel guardarL)
        {

            return View(guardarL);



        }

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioModel informacion)
        {
            ErrorViewModel errorViewModel = new ErrorViewModel();
            try
            {
                Encryptar clave = new Encryptar();
                informacion.Contrasena = clave.Encrypt(informacion.Contrasena);
                bool rsp = await repousuario.ValidarUsuario(informacion);
                if (rsp)
                {
                    IEnumerable<InsertarProductoModel> productos = RepoHome.ListarProductos();
                    return View("~/Views/Home/Principal.cshtml", productos);
                }
                return View("Index");
            }
            catch (Exception error)
            {
                errorViewModel.RequestId = error.HResult.ToString();
                errorViewModel.message = error.HResult.ToString();
            }
            return View("Error", errorViewModel);
        }
        public IActionResult Registro(RegistrarModel datos)
        {
            if(!ModelState.IsValid)
            {
                return View("~/Views/Home/Registro.cshtml", datos);
            }
            Encryptar encryptar = new Encryptar();
            datos.Contrasena = encryptar.Encrypt(datos.Contrasena);

            repousuario.RegistrarModel(datos);
            TempData["SucessMessage"] = "El Registro Fue Exitoso";
            return View("~/Views/Home/Registro.cshtml");
        }
    }
}
