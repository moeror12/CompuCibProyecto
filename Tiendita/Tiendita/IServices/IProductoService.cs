using Microsoft.AspNetCore.Mvc;
using Tiendita.Models;

namespace Tiendita.IServices
{
    public interface IProductoService
    {
        public List<Producto> ListarProducto();
        public Producto ObtenerProducto(int productoId);
        public int RegistrarProducto(Producto p);
        public int ActualizarProducto(Producto p);
        public int EliminarProducto(int pId);
        public List<Categoria> ListarCategorias();
        
    }
}
