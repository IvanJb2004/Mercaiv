using Mercaiv.Models.Servicio;
using Mercaiv.Servicio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Mercaiv.Models;

namespace Mercaiv.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositorioHome RepoHome;
       

        public HomeController( IRepositorioHome repoHome)
        {
           
            this.RepoHome = repoHome;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Registro()
        {
            return View();
        }






        //public IActionResult Registrar(RegistrarModel datos)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return View(datos);
        //        }
        //        repousuario.RegistrarModel(datos);
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return View("~/Views/Home/Registro.cshtml");

        //}

        public IActionResult Principal()
        {
            IEnumerable<InsertarProductoModel> productos =RepoHome.ListarProductos();
            return View(productos);
        }

    }
}
