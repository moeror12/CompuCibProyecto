using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ProyectoCompuCibVista.Models;
using System.Net.Http.Formatting;
using System.Text;

namespace ProyectoCompuCibVista.Controllers
{
    public class ClienteController : Controller
    {
        async Task<List<Cliente>> getClientes()
        {
            List<Cliente> temporal = new List<Cliente>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/api/Cliente/getClientes");
                HttpResponseMessage mensaje = await client.GetAsync("getClientes");
                string cadena = await mensaje.Content.ReadAsStringAsync();

                temporal = JsonConvert.DeserializeObject<List<Cliente>>(cadena).Select(
                    s => new Cliente
                    {
                        IdCliente= s.IdCliente,
                        CodigoCliente = s.CodigoCliente,
                        nombre = s.nombre,
                        apellido = s.apellido,
                        direccion = s.direccion,
                        correo = s.correo,
                        contrasenia = s.contrasenia,
                        dni = s.dni,
                    }).ToList();
            }
            return temporal;
        }

        [HttpGet]
        async Task<List<Cliente>> getCliente(int clienteId)
        {
            List<Cliente> temporal = new List<Cliente>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/api/Cliente/obtenerCliente/" + clienteId);
                HttpResponseMessage mensaje = await client.GetAsync("getClientes");
                string cadena = await mensaje.Content.ReadAsStringAsync();

                temporal = JsonConvert.DeserializeObject<List<Cliente>>(cadena).Select(
                    s => new Cliente
                    {
                        IdCliente = s.IdCliente,
                        CodigoCliente = s.CodigoCliente,
                        nombre = s.nombre,
                        apellido = s.apellido,
                        direccion = s.direccion,
                        correo = s.correo,
                        contrasenia = s.contrasenia,
                        dni = s.dni,
                    }).ToList();
            }
            return temporal;
        }

        //[HttpGet]
        //async Task<List<Producto>> getProductosxCat(int categoriaId)
        //{
        //    List<Producto> temporal = new List<Producto>();
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:7258/");
        //        HttpResponseMessage mensaje = await client.GetAsync("api/Producto/obtenerProductoxCategoria/" + categoriaId);
        //        string cadena = await mensaje.Content.ReadAsStringAsync();

        //        temporal = JsonConvert.DeserializeObject<List<Producto>>(cadena).Select(
        //            s => new Producto
        //            {
        //                ProductoId = s.ProductoId,
        //                Nombre = s.Nombre,
        //                Precio = s.Precio,
        //                FechaCreacion = s.FechaCreacion,
        //                Foto = s.Foto,
        //                CategoriaId = s.CategoriaId,
        //                Categoria = s.Categoria,
        //                Stock = s.Stock,
        //            }).ToList();
        //    }
        //    return temporal;
        //}

        //[HttpGet]
        //async Task<List<Producto>> getProductosxNom(string nom)
        //{
        //    List<Producto> temporal = new List<Producto>();
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:7258/");
        //        HttpResponseMessage mensaje = await client.GetAsync("api/Producto/obtenerProductoxNom/" + nom);
        //        string cadena = await mensaje.Content.ReadAsStringAsync();

        //        temporal = JsonConvert.DeserializeObject<List<Producto>>(cadena).Select(
        //            s => new Producto
        //            {
        //                ProductoId = s.ProductoId,
        //                Nombre = s.Nombre,
        //                Precio = s.Precio,
        //                FechaCreacion = s.FechaCreacion,
        //                Foto = s.Foto,
        //                CategoriaId = s.CategoriaId,
        //                Categoria = s.Categoria,
        //                Stock = s.Stock,
        //            }).ToList();
        //    }
        //    return temporal;
        //}
        //async Task<List<Categoria>> getCategorias()
        //{
        //    List<Categoria> temporal = new List<Categoria>();
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:7258/api/Categoria/getCategorias");
        //        HttpResponseMessage mensaje = await client.GetAsync("getCategorias");
        //        string cadena = await mensaje.Content.ReadAsStringAsync();

        //        temporal = JsonConvert.DeserializeObject<List<Categoria>>(cadena).Select(
        //            s => new Categoria
        //            {
        //                CategoriaId = s.CategoriaId,
        //                Nombre = s.Nombre,
        //            }).ToList();
        //    }
        //    return temporal;
        //}
        public async Task<IActionResult> Index()
        {
            return View(await getClientes());
        }

        public async Task<IActionResult> Create()
        {
            return View(await Task.Run(() => new Cliente()));
        }
        //public async Task<IActionResult> ProductosxCat(int categoriaId = 0)
        //{
        //    ViewBag.cat = categoriaId;
        //    ViewBag.categoria = new SelectList(getCategorias().Result, "CategoriaId", "Nombre");
        //    return View(await getProductosxCat(categoriaId));
        //}

        //public async Task<IActionResult> ProductosxNom(string nom = "")
        //{

        //    return View(await getProductosxNom(nom));
        //}
        [HttpPost]
        public async Task<IActionResult> Create(Cliente reg)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/api/Cliente/createCliente");
                StringContent contenido = new StringContent(JsonConvert.SerializeObject(reg), Encoding.UTF8, "application/json");
                HttpResponseMessage msg = await client.PostAsync("createCliente", contenido);
                mensaje = await msg.Content.ReadAsStringAsync();

            }
            if (mensaje == "1")
            {
                ViewBag.mensaje = "El Cliente se Creó Correctamente!";
                TempData["mensaje"] = "Cliente registrado correctamente";
                ViewBag.code = "1";
                return View(await Task.Run(() => reg));
            }
            else if (mensaje == "2")
            {
                ViewBag.mensaje = "El Cliente ya existe!";
                ViewBag.code = "2";
                return View(await Task.Run(() => reg));
            }
            else
            {
                ViewBag.mensaje = "Error al Crear el Cliente";
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
            var request = clienteHttp.GetAsync("api/Producto/obtenerCliente/" + id).Result;

            var resultString = request.Content.ReadAsStringAsync().Result;
            var objE = JsonConvert.DeserializeObject<Cliente>(resultString);
            return View(objE);
        }
        [HttpPost]
        public ActionResult Edit(Cliente objE)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/");
            var request = clienteHttp.PutAsync("/api/Cliente/UpdateCliente", objE, new
            JsonMediaTypeFormatter()).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var estado = JsonConvert.DeserializeObject<int>(resultString);
                if (estado == 1)
                {
                    ViewBag.mensaje = estado + " Cliente actualizado correctamente..!!";
                    ViewBag.code = "1";
                    return View(objE);
                }
                else
                {
                    ViewBag.mensaje = "Error al actualizar el Cliente";
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
            var request = clienteHttp.GetAsync("api/Cliente/obtenerCliente/" + id).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var objE = JsonConvert.DeserializeObject<Cliente>(resultString);
                return View(objE);
            }

            return View();
        }
        [HttpGet]
        public ActionResult eliminarCliente(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/");
            var request = clienteHttp.DeleteAsync("api/Cliente/eliminarCliente/" + id).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var estado = JsonConvert.DeserializeObject<bool>(resultString);
                if (estado)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

    
}
}
