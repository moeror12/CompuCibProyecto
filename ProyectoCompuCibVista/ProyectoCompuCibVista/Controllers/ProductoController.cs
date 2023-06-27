using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ProyectoCompuCibVista.Models;
using System.Linq.Expressions;
using System.Net.Http.Formatting;
using System.Numerics;
using System.Text;

namespace ProyectoCompuCibVista.Controllers
{
    public class ProductoController : Controller
    {

        async Task<List<Producto>> getProductos()
        {
            List<Producto> temporal = new List<Producto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/api/Producto/getProducts");
                HttpResponseMessage mensaje = await client.GetAsync("getProducts");
                string cadena = await mensaje.Content.ReadAsStringAsync();

                temporal = JsonConvert.DeserializeObject<List<Producto>>(cadena).Select(
                    s => new Producto
                    {
                        ProductoId = s.ProductoId,
                        Nombre = s.Nombre,
                        Precio = s.Precio,
                        FechaCreacion = s.FechaCreacion,
                        Foto = s.Foto,
                        Descripcion = s.Descripcion,
                        CategoriaId = s.CategoriaId,
                        Categoria = s.Categoria,
                        Stock = s.Stock,
                    }).ToList();
            }
            return temporal;
        }

        [HttpGet]
        async Task<List<Producto>> getProducto(int productId)
        {
            List<Producto> temporal = new List<Producto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/api/Producto/obtenerProducto/" + productId);
                HttpResponseMessage mensaje = await client.GetAsync("getProducts");
                string cadena = await mensaje.Content.ReadAsStringAsync();

                temporal = JsonConvert.DeserializeObject<List<Producto>>(cadena).Select(
                    s => new Producto
                    {
                        ProductoId = s.ProductoId,
                        Nombre = s.Nombre,
                        Precio = s.Precio,
                        FechaCreacion = s.FechaCreacion,
                        Foto = s.Foto,
                        Descripcion = s.Descripcion,
                        CategoriaId = s.CategoriaId,
                        Categoria = s.Categoria,
                        Stock = s.Stock,
                    }).ToList();
            }
            return temporal;
        }

        [HttpGet]
        async Task<List<Producto>> getProductosxCat(int categoriaId)
        {
            List<Producto> temporal = new List<Producto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/");
                HttpResponseMessage mensaje = await client.GetAsync("api/Producto/obtenerProductoxCategoria/"+ categoriaId);
                string cadena = await mensaje.Content.ReadAsStringAsync();

                temporal = JsonConvert.DeserializeObject<List<Producto>>(cadena).Select(
                    s => new Producto
                    {
                        ProductoId = s.ProductoId,
                        Nombre = s.Nombre,
                        Precio = s.Precio,
                        FechaCreacion = s.FechaCreacion,
                        Foto = s.Foto,
                        Descripcion = s.Descripcion,
                        CategoriaId = s.CategoriaId,
                        Categoria = s.Categoria,
                        Stock = s.Stock,
                    }).ToList();
            }
            return temporal;
        }

        [HttpGet]
        async Task<List<Producto>> getProductosxNom(string nom)
        {
            List<Producto> temporal = new List<Producto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/");
                HttpResponseMessage mensaje = await client.GetAsync("api/Producto/obtenerProductoxNom/"+ nom);
                string cadena = await mensaje.Content.ReadAsStringAsync();

                temporal = JsonConvert.DeserializeObject<List<Producto>>(cadena).Select(
                    s => new Producto
                    {
                        ProductoId = s.ProductoId,
                        Nombre = s.Nombre,
                        Precio = s.Precio,
                        FechaCreacion = s.FechaCreacion,
                        Foto = s.Foto,
                        Descripcion = s.Descripcion,
                        CategoriaId = s.CategoriaId,
                        Categoria = s.Categoria,
                        Stock = s.Stock,
                    }).ToList();
            }
            return temporal;
        }
        async Task<List<Categoria>> getCategorias()
        {
            List<Categoria> temporal = new List<Categoria>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/api/Categoria/getCategorias");
                HttpResponseMessage mensaje = await client.GetAsync("getCategorias");
                string cadena = await mensaje.Content.ReadAsStringAsync();

                temporal = JsonConvert.DeserializeObject<List<Categoria>>(cadena).Select(
                    s => new Categoria
                    {
                        CategoriaId = s.CategoriaId,
                        Nombre = s.Nombre,
                    }).ToList();
            }
            return temporal;
        }
        public async Task<IActionResult> Index()
        {
            return View(await getProductos());
        }
        
        public async Task<IActionResult> Create()
        {
            return View(await Task.Run(() => new Producto()));
        }
        public async Task<IActionResult> ProductosxCat(int categoriaId=0)
        {
            ViewBag.cat = categoriaId;
            ViewBag.categoria = new SelectList(getCategorias().Result, "CategoriaId", "Nombre");
            return View(await getProductosxCat(categoriaId));
        }

        public async Task<IActionResult> ProductosxNom(string nom)
        {
            ViewBag.nom = nom;
            return View(await getProductosxNom(nom));
        }
        [HttpPost]
        public async Task<IActionResult> Create(Producto reg)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/api/Producto/createProduct");
                StringContent contenido = new StringContent(JsonConvert.SerializeObject(reg), Encoding.UTF8, "application/json");
                HttpResponseMessage msg = await client.PostAsync("createProduct", contenido);
                mensaje=await msg.Content.ReadAsStringAsync();

            }
            if (mensaje == "1")
            {
                ViewBag.mensaje = "El Producto se Creó Correctamente!";
                TempData["mensaje"] = "Producto registrado correctamente";
                ViewBag.code = "1";
                return View(await Task.Run(() => reg));
            }
            else if (mensaje == "2")
            {
                ViewBag.mensaje = "El Producto ya existe!";
                ViewBag.code = "2";
                return View(await Task.Run(() => reg));
            }
            else {
                ViewBag.mensaje = "Error al Crear el Producto";
                ViewBag.code = "0";
                return View(await Task.Run(() => reg));
            }
            //ViewBag.categorias = new SelectList(await getCategorias(), "CategoriaId", "nombre", reg.CategoriaId);
            //return View(await Task.Run(() => reg));
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/");
            var request = clienteHttp.GetAsync("api/Producto/obtenerProducto/" + id).Result;

                var resultString = request.Content.ReadAsStringAsync().Result;
                var objE = JsonConvert.DeserializeObject<Producto>(resultString);
            return View(objE);
        }
        [HttpPost]
        public ActionResult Edit(Producto objE)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/");
            var request = clienteHttp.PutAsync("/api/Producto/UpdateProduct", objE, new
            JsonMediaTypeFormatter()).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var estado = JsonConvert.DeserializeObject<int>(resultString);
                if (estado == 1)
                {
                    ViewBag.mensaje = estado + " Producto actualizado correctamente..!!";
                    ViewBag.code = "1";
                    return View(objE);
                }
                else
                {
                    ViewBag.mensaje = "Error al actualizar el Producto";
                    ViewBag.code = "0";
                    return View(objE);
                }
                //return View(objE);
            }
            return View();
        }
    
        [HttpGet]
        public ActionResult Details(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/");
            var request = clienteHttp.GetAsync("api/Producto/obtenerProducto/" + id).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var objE = JsonConvert.DeserializeObject<Producto>(resultString);
                return View(objE);
            }

            return View();
        }
        [HttpGet]
        public ActionResult eliminarProducto(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/");
            var request = clienteHttp.DeleteAsync("api/Producto/eliminarProducto/" + id).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var estado = JsonConvert.DeserializeObject<bool>(resultString);
                if (estado)
                {
                    return RedirectToAction("ProductosxCat");
                }
            }
            return View();
        }

    }
}
