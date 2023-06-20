using Tiendita.Models;

namespace Tiendita.IServices
{
    public interface IVentaService
    {
        public List<Venta> ListarVenta();
        public Venta ObtenerVenta(int ventaId);

        public int RegistrarVenta(Venta u);
        public int ActualizarVenta(Venta v);
        public int EliminarVenta(int vId);
    }
}
