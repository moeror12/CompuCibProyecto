namespace Tiendita.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Foto { get; set; }
        public string Descripcion { get; set; }
        public int CategoriaId { get; set; }
        public string Categoria { get; set; }
        public int Stock { get; set; }
    }
}
