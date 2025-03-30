namespace Mercaiv.Models
{
    public class CarritoModel
    {
        public int idProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Preciov { get; set; }

        public string Descripcion { get; set; }
        public string urlimagen { get; set; }

    }

    public class carroitem
    {
        public CarritoModel Producto { get; set; }
        public int Cantidad { get; set; }
    }
    public class ProductoSeleccionados
    {
        public List<carroitem> items { get; set; } = new List<carroitem>();
        public decimal TotalPrecio => items.Sum(item => item.Producto.Preciov * item.Cantidad);
    }
}
