using System.ComponentModel.DataAnnotations;

namespace  Mercaiv.Models;

public class RegistrarModel
{
    [Required(ErrorMessage = "El Campo {0} Es Requerido" )]
    public string Nombre { get; set; }
    [Required(ErrorMessage = "El Campo {0} Es Requerido")]
    public string Apellido { get; set; }
    [Required(ErrorMessage = "El Campo {0} Es Requerido")]
    public string Correo { get; set; }
    [Required(ErrorMessage = "El Campo {0} Es Requerido")]
    public string Fecha { get; set; }
    [Required(ErrorMessage = "El Campo {0} Es Requerido")]
    public string Identificacion { get; set; }
    [Required(ErrorMessage = "El Campo {0} Es Requerido")]
    public string Genero { get; set; }
    [Required(ErrorMessage = "El Campo {0} Es Requerido")]
    public string Contrasena { get; set; }
    [Required(ErrorMessage = "El Campo {0} Es Requerido")]
    public string Confirmar { get; set; }
}