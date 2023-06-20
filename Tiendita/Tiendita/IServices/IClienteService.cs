using Tiendita.Models;

namespace Tiendita.IServices
{
    public interface IClienteService
    {
        public List<Cliente> ListarClientes();
        public Cliente ObtenerCliente(int clienteId);
        public int RegistrarCliente(Cliente c);
        public int ActualizarCliente(Cliente c);
        public int EliminarCliente(int cId);
    }
}
