using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiendita.IServices;
using Tiendita.Models;

namespace Tiendita.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        ICategoriaService categoriaService;

        public CategoriaController(ICategoriaService service)
        {
            categoriaService = service;
        }

        [HttpGet]
        [Route("[action]/{categoriaId}")]
        public IActionResult obtenerCategoria(int categoriaId)
        {
            var obj = categoriaService.ObtenerCategoria(categoriaId);
            return Ok(obj);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult getCategorias()
        {
            var lista = categoriaService.ListarCategorias();
            return Ok(lista);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult createCategorias([FromBody] Categoria categoria)
        {
            var resultado = categoriaService.RegistrarCategoria(categoria);
            return Ok(resultado);
        }

        [HttpPut]
        [Route("[action]")]
        public IActionResult updateCategorias([FromBody] Categoria categoria)
        {
            var resultado = categoriaService.ActualizarCategoria(categoria);
            return Ok(resultado);
        }

        [HttpDelete]
        [Route("[action]/{categoriaId}")]
        public IActionResult eliminarCategoria(int categoriaId)
        {
            var resultado = categoriaService.EliminarCategoria(categoriaId);
            return Ok(resultado);
        }
    }
}
