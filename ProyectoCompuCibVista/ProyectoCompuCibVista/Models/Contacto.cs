using System.ComponentModel.DataAnnotations;

namespace ProyectoCompuCibVista.Models
{
    public class Contacto
    {
        public int IdContacta { get; set; }
        [Required(ErrorMessage = "Porfavor ingrese Nombre y Apellidos")]
        public string nombreapellido { get; set; }
        [Required(ErrorMessage = "Porfavor ingrese Correo")]
        public string correo { get; set; }
        [Required(ErrorMessage = "Porfavor ingrese Asunto")]
        public string asunto { get; set; }
        [Required(ErrorMessage = "Porfavor ingrese Mensaje")]
        public string mensaje { get; set; }
    }
}
