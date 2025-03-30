using System.ComponentModel.DataAnnotations;

namespace Mercaiv.Models
{
    public class UsuarioModel
    {
        [Required(ErrorMessage = "El Campo {0} Es Requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Campo {0} Es Requerido")]
        public string Contrasena {  get; set; }
    }
}
