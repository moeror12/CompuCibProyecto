using Tiendita.Models;

namespace Tiendita.IServices
{
    public interface ICategoriaService
    {
        public List<Categoria> ListarCategorias();
        public Categoria ObtenerCategoria(int categoriaId);
        public int RegistrarCategoria(Categoria c);
        public int ActualizarCategoria(Categoria c);
        public int EliminarCategoria(int cId);
    }
}
