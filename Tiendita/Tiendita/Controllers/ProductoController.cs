using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiendita.IServices;
using Tiendita.Models;

namespace Tiendita.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        IProductoService productoService;

        public ProductoController(IProductoService service)
        {
            productoService = service;
        }
        
        [HttpGet]
        [Route("[action]/{productoId}")]
        public IActionResult obtenerProducto(int productoId)
        {
            var obj = productoService.ObtenerProducto(productoId);
            return Ok(obj);
        }
        
        [HttpGet]
        [Route("[action]")]
        public IActionResult getProducts()
        {
            var lista = productoService.ListarProducto();
            return Ok(lista);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult createProduct([FromBody] Producto producto)
        {
            var resultado = productoService.RegistrarProducto(producto);
            return Ok(resultado);
        }

        [HttpPut]
        [Route("[action]")]
        public IActionResult updateProduct([FromBody] Producto producto)
        {
            var resultado = productoService.ActualizarProducto(producto);
            return Ok(resultado);
        }

        [HttpDelete]
        [Route("[action]/{productoId}")]
        public IActionResult eliminarProducto(int productoId)
        {
            var resultado = productoService.EliminarProducto(productoId);
            return Ok(resultado);
        }
        /*
         {
          "productoId": 0,
          "nombre": "Roberto",
          "precio": 30,
          "fechaCreacion": "2023-05-18T01:43:27.143Z",
          "foto": "https://assets.vogue.in/photos/5d7224d50ce95e0008696c55/2:3/w_1600,c_limit/Joker.jpg",
            "categoriaId": 1,
            "categoria": "Laptop",
            "stock": 20
        }
        */
    }
}
