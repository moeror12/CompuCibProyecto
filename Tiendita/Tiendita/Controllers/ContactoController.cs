using Microsoft.AspNetCore.Mvc;
using Tiendita.IServices;
using Tiendita.Models;

namespace Tiendita.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController : ControllerBase
    {
        IContactoService contactoService;

        public ContactoController(IContactoService service)
        {
            contactoService = service;
        }
        [HttpGet]
        [Route("[action]/{contactoId}")]
        public IActionResult obtenerContacto(int contactoId)
        {
            var obj = contactoService.ObtenerContacto(contactoId);
            return Ok(obj);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult getContactos()
        {
            var lista = contactoService.ListarContacto();
            return Ok(lista);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult createContacto([FromBody] Contacto contacto)
        {
            var resultado = contactoService.RegistrarContacto(contacto);
            return Ok(resultado);
        }
        [HttpPut]
        [Route("[action]")]
        public IActionResult updateContacto([FromBody] Contacto contacto)
        {
            var resultado = contactoService.ActualizarContacto(contacto);
            return Ok(resultado);
        }
        [HttpDelete]
        [Route("[action]/{contactoId}")]
        public IActionResult eliminarContacto(int contactoId)
        {
            var resultado = contactoService.EliminarContacto(contactoId);
            return Ok(resultado);
        }
    }
}
