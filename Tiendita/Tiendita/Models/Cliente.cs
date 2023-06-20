using System.Net;

namespace Tiendita.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string CodigoCliente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public string correo { get; set; }
        public string contrasenia { get; set; }
        public int dni { get; set; }
    }
}
