namespace Tiendita.Models
{
    public class Reclamo
    {
        public int IdReclamo { get; set; }
        public string descripcion { get; set; }
        public DateTime DiaReclamo { get; set; }
        public int IdVenta { get; set; }
    }
}
