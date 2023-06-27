using Microsoft.AspNetCore.Mvc;
using Tiendita.IServices;
using Tiendita.Models;

namespace Tiendita.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleOrdenController : ControllerBase
    {
        IDetalleOrdenService detalleOrdenService;

        public DetalleOrdenController(IDetalleOrdenService service)
        {
            detalleOrdenService = service;
        }

        [HttpGet]
        [Route("[action]/{detalleOrdenId}")]
        public IActionResult obtenerDetalleOrden(int detalleOrdenId)
        {
            var obj = detalleOrdenService.ObtenerDetalleOrden(detalleOrdenId);
            return Ok(obj);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult getDetalleOrdenes()
        {
            var lista = detalleOrdenService.ListarDetalleOrden();
            return Ok(lista);
        }

        [HttpPut]
        [Route("[action]")]
        public IActionResult updateDetalleOrden([FromBody] DetalleOrden detalleOrden)
        {
            var resultado = detalleOrdenService.ActualizarDetalleOrden(detalleOrden);
            return Ok(resultado);
        }

        [HttpDelete]
        [Route("[action]/{detalleOrdenId}")]
        public IActionResult eliminarDetalleOrden(int detalleOrdenId)
        {
            var resultado = detalleOrdenService.EliminarDetalleOrden(detalleOrdenId);
            return Ok(resultado);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult createDetalleOrden(List<DetalleOrden> detalleOrden)
        {
            var resultado = detalleOrdenService.RegistrarDetalleOrden(detalleOrden);
            return Ok(resultado);
        }
    }
}
