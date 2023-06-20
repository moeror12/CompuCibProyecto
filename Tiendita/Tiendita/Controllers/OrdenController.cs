using Microsoft.AspNetCore.Mvc;
using Tiendita.IServices;
using Tiendita.Models;

namespace Tiendita.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        IOrdenService ordenService;

        public OrdenController(IOrdenService service)
        {
            ordenService = service;
        }

        [HttpGet]
        [Route("[action]/{ordenId}")]
        public IActionResult obtenerOrden(int ordenId)
        {
            var obj = ordenService.ObtenerOrden(ordenId);
            return Ok(obj);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult getOrdenes()
        {
            var lista = ordenService.ListarOrden();
            return Ok(lista);
        }

        [HttpPut]
        [Route("[action]")]
        public IActionResult updateOrden([FromBody] Orden orden)
        {
            var resultado = ordenService.ActualizarOrden(orden);
            return Ok(resultado);
        }

        [HttpDelete]
        [Route("[action]/{ordenId}")]
        public IActionResult eliminarOrden(int ordenId)
        {
            var resultado = ordenService.EliminarOrden(ordenId);
            return Ok(resultado);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult createOrden([FromBody] Orden orden)
        {
            var resultado = ordenService.RegistrarOrden(orden);
            return Ok(resultado);
        }
    }
}
