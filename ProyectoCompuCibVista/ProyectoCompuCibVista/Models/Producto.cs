using System.ComponentModel.DataAnnotations;

namespace ProyectoCompuCibVista.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "Campo nombre del producto es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Porfavor ingrese precio")]
        public decimal Precio { get; set; }
        public DateTime FechaCreacion { get; set; }
        [Required(ErrorMessage = "Porfavor elija una imagen de producto")]
        public string Foto { get; set; }
        [Required(ErrorMessage = "Porfavor escriba una descripcion de producto")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Porfavor seleccione una categoria")]
        public int CategoriaId { get; set; }
        public string Categoria { get; set; }
        public int Stock { get; set; }
    }
}
