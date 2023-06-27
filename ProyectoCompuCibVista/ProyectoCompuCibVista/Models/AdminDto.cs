using System.ComponentModel.DataAnnotations;

namespace ProyectoCompuCibVista.Models
{
    public class AdminDto
    {
        [Required(ErrorMessage = "Porfavor ingrese Codigo de Usuario")]
        public string CodigoUsuario { get; set; }
        [Required(ErrorMessage = "Porfavor ingrese Password")]
        public string Password { get; set; }
    }
}
