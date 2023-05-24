namespace Tiendita.Models
{
    public class Venta
    {
        public int VentaId { get; set; }
        public DateTime DiaVenta { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
    }
}
