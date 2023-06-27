namespace Tiendita.Models
{
    public class DetalleOrden
    {
        public int IdDetalleOrden { get; set; }
        public string nomProducto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public int IdOrden { get; set; }
    }
}
