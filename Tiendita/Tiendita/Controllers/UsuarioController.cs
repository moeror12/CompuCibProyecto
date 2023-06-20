using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Tiendita.IServices;
using Tiendita.Models;
using Tiendita.Services;
using System.Text.Json;

namespace Tiendita.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService service)
        {
            usuarioService = service;
        }
        [HttpGet]
        [Route("[action]/{usuarioId}")]
        public IActionResult obtenerUsuario(int usuarioId)
        {
            var obj = usuarioService.ObtenerUsuario(usuarioId);
            return Ok(obj);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult getUsuario()
        {
            var lista = usuarioService.ListarUsuario();
            return Ok(lista);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult createUsuario([FromBody] Usuario usuario)
        {
            var resultado = usuarioService.RegistrarUsuario(usuario);
            return Ok(resultado);
        }
        [HttpPut]
        [Route("[action]")]
        public IActionResult updateUsuario([FromBody] Usuario usuario)
        {
            var resultado = usuarioService.ActualizarUsuario(usuario);
            return Ok(resultado);
        }
        [HttpDelete]
        [Route("[action]/{usuarioId}")]
        public IActionResult eliminarUsuario(int usuarioId)
        {
            var resultado = usuarioService.EliminarUsuario(usuarioId);
            return Ok(resultado);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login([FromBody] AdminDto userLogin)
        {
            var user = Authenticate(userLogin);
            if (user != null)
            {
                return Ok("1");

            }
            return NotFound("2");
        }
        private Usuario Authenticate(AdminDto userlogin)
        {
            var actn = usuarioService.ListarUsuario();
            var currentuser = actn.FirstOrDefault(user => user.CodigoUsuario == userlogin.CodigoUsuario
            && user.Password == userlogin.Password);
            if (currentuser != null)
            {
                return currentuser;
            }
            return null;
        }
    }
}
