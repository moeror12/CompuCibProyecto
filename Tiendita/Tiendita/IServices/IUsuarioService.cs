using Tiendita.Models;

namespace Tiendita.IServices
{
    public interface IUsuarioService
    {
        public List<Usuario> ListarUsuario();
        public Usuario ObtenerUsuario(int usuarioId);
        public int RegistrarUsuario(Usuario u);
        public int ActualizarUsuario(Usuario u);
        public int EliminarUsuario(int uId);
    }
}
