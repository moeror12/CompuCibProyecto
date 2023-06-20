using Tiendita.Models;

namespace Tiendita.IServices
{
    public interface IContactoService
    {
        public List<Contacto> ListarContacto();
        public Contacto ObtenerContacto(int contactoId);
        public int RegistrarContacto(Contacto c);
        public int ActualizarContacto(Contacto c);
        public int EliminarContacto(int cId);
    }
}
