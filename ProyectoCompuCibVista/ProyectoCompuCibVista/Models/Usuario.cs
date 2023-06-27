using System.ComponentModel.DataAnnotations;

namespace ProyectoCompuCibVista.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Porfavor ingrese Codigo Usuario")]
        public string CodigoUsuario { get; set; }
        [Required(ErrorMessage = "Porfavor ingrese Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Porfavor ingrese Apellido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Porfavor ingrese Correo")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Porfavor ingrese Direccion")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Porfavor ingrese Telefono")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Porfavor ingrese Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Porfavor ingrese Tipo de usuario")]
        public int TipoUsuarioId { get; set; }
    }
}
