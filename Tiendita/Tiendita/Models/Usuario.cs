namespace Tiendita.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string NombreCompleto { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public int TipoUsuarioId { get; set; }
    }
}
