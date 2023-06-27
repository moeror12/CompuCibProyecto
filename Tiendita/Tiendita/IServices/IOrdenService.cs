using Tiendita.Models;

namespace Tiendita.IServices
{
    public interface IOrdenService
    {
        public List<Orden> ListarOrden();
        public Orden ObtenerOrden(int ordenId);

        public int RegistrarOrden(Orden o);
        public int ActualizarOrden(Orden o);
        public int EliminarOrden(int oId);
    }
}
