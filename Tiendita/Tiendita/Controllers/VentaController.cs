using Microsoft.AspNetCore.Mvc;
using Tiendita.IServices;
using Tiendita.Models;
using Tiendita.Services;

namespace Tiendita.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        IVentaService ventaService;

        public VentaController(IVentaService service)
        {
            ventaService = service;
        }

        [HttpGet]
        [Route("[action]/{ventaId}")]
        public IActionResult obtenerVenta(int ventaId)
        {
            var obj = ventaService.ObtenerVenta(ventaId);
            return Ok(obj);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult getVentas()
        {
            var lista = ventaService.ListarVenta();
            return Ok(lista);
        }

        [HttpPut]
        [Route("[action]")]
        public IActionResult updateVenta([FromBody] Venta venta)
        {
            var resultado = ventaService.ActualizarVenta(venta);
            return Ok(resultado);
        }

        [HttpDelete]
        [Route("[action]/{ventaId}")]
        public IActionResult eliminarVenta(int ventaId)
        {
            var resultado = ventaService.EliminarVenta(ventaId);
            return Ok(resultado);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult createVenta([FromBody] Venta venta)
        {
            var resultado = ventaService.RegistrarVenta(venta);
            return Ok(resultado);
        }
    }
}
