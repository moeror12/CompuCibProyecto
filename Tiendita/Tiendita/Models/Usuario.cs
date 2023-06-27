namespace Tiendita.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string CodigoUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Password { get; set; }
        public int TipoUsuarioId { get; set; }
    }
}
