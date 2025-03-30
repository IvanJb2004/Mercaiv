using System.ComponentModel.DataAnnotations;


namespace Mercaiv.Models;

public class InsertarProductoModel
{

    public string idProducto { get; set; }
    [Required(ErrorMessage = "El Campo {0} Es Requerido")]
    public string Codigo { get; set; }

    [Required(ErrorMessage = "El Campo {0} Es Requerido")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El Campo {0} Es Requerido")]
    public string Descripcion { get; set; }

    [Required(ErrorMessage = "El Campo {0} Es Requerido")]
    public string Preciov { get; set; }

    [Required(ErrorMessage = "El Campo {0} Es Requerido")]
    public string Unidades { get; set; }

   
    public string Estado { get; set; }

    [Required(ErrorMessage = "Por Favor, Seleccione Una Imagen")]
    [DataType(DataType.Upload)]
    public  IFormFile Imagen  {  get; set; }
 
    public string urlimagen { get; set; }

    [Required(ErrorMessage = "El Campo {0} Es Requerido")]
    public string Marca { get; set; }

    [Required(ErrorMessage = "El Campo {0} Es Requerido")]
    public string Color {  get; set; }

    [Required(ErrorMessage = "El Campo {0} Es Requerido")]
    public string Modelo { get; set; }
}
