using Microsoft.AspNetCore.Mvc;
using Tiendita.IServices;
using Tiendita.Models;
using Tiendita.Services;

namespace Tiendita.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        IClienteService clienteService;

        public ClienteController(IClienteService service)
        {
            clienteService = service;
        }
        [HttpGet]
        [Route("[action]/{clienteId}")]
        public IActionResult obtenerCliente(int clienteId)
        {
            var obj = clienteService.ObtenerCliente(clienteId);
            return Ok(obj);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult getClientes()
        {
            var lista = clienteService.ListarClientes();
            return Ok(lista);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult createCliente([FromBody] Cliente cliente)
        {
            var resultado = clienteService.RegistrarCliente(cliente);
            return Ok(resultado);
        }
        [HttpPut]
        [Route("[action]")]
        public IActionResult updateCliente([FromBody] Cliente cliente)
        {
            var resultado = clienteService.ActualizarCliente(cliente);
            return Ok(resultado);
        }
        [HttpDelete]
        [Route("[action]/{clienteId}")]
        public IActionResult eliminarCliente(int clienteId)
        {
            var resultado = clienteService.EliminarCliente(clienteId);
            return Ok(resultado);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login([FromBody] ClienteDto userLogin)
        {
            var user = Authenticate(userLogin);
            if (user != null)
            {
                return Ok("{ \"resultado\": \"" + userLogin.correo+ "\"}");

            }
            return NotFound("{ \"resultado\": \"" + "2" + "\"}");
        }
        private Cliente Authenticate(ClienteDto userlogin)
        {
            var actn = clienteService.ListarClientes();
            var currentuser = actn.FirstOrDefault(user => user.correo == userlogin.correo
            && user.contrasenia == userlogin.contrasenia);
            if (currentuser != null)
            {
                return currentuser;
            }
            return null;
        }
    }
}
