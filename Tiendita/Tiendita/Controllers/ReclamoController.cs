using Microsoft.AspNetCore.Mvc;
using Tiendita.IServices;
using Tiendita.Models;

namespace Tiendita.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReclamoController : ControllerBase
    {
        IReclamoService reclamoService;

        public ReclamoController(IReclamoService service)
        {
            reclamoService = service;
        }

        [HttpGet]
        [Route("[action]/{rId}")]
        public IActionResult obtenerReclamo(int rId)
        {
            var obj = reclamoService.ObtenerReclamo(rId);
            return Ok(obj);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult getReclamos()
        {
            var lista = reclamoService.ListarRelcamos();
            return Ok(lista);
        }
        [HttpGet]
        [Route("[action]/{correo?}")]
        public IActionResult obtenerReclamoxCorreo(string? correo = null)
        {
            var obj = reclamoService.listReclamosxCorreo(correo);
            return Ok(obj);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult createReclamo([FromBody] Reclamo reclamo)
        {
            var resultado = reclamoService.RegistrarReclamo(reclamo);
            return Ok(resultado);
        }

        [HttpPut]
        [Route("[action]")]
        public IActionResult updateReclamo([FromBody] Reclamo reclamo)
        {
            var resultado = reclamoService.ActualizarReclamo(reclamo);
            return Ok(resultado);
        }

        [HttpDelete]
        [Route("[action]/{rId}")]
        public IActionResult eliminarReclamo(int rId)
        {
            var resultado = reclamoService.EliminarReclamo(rId);
            return Ok(resultado);
        }
    }
}
