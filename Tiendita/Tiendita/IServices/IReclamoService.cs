using Tiendita.Models;

namespace Tiendita.IServices
{
    public interface IReclamoService
    {
        public List<Reclamo> ListarRelcamos();
        public Reclamo ObtenerReclamo(int rId);
        public int RegistrarReclamo(Reclamo r);
        public int ActualizarReclamo(Reclamo r);

        public ReclamoN numeroReclamos();
        public int EliminarReclamo(int rId);
        public List<Reclamo> listReclamosxCorreo(string correo);
    }
}
