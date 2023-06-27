using Microsoft.AspNetCore.Mvc;
using ProyectoCompuCibVista.DAO;
using ProyectoCompuCibVista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http.Formatting;

namespace ProyectoCompuCibVista.Controllers
{
    public class SeguridadController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(await getProductos());
        }
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
                        CategoriaId = s.CategoriaId,
                        Categoria = s.Categoria,
                        Stock = s.Stock,
                    }).ToList();
            }
            return temporal;
        }
        public async Task<IActionResult> Login()
        {
            return View(await Task.Run(() => new AdminDto()));
        }
        [HttpPost]
        public async Task<IActionResult> Login(AdminDto objE)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/api/Usuario/Login");
                StringContent contenido = new StringContent(JsonConvert.SerializeObject(objE), Encoding.UTF8, "application/json");
                HttpResponseMessage msg = await client.PostAsync("Login", contenido);
                mensaje = await msg.Content.ReadAsStringAsync();

            }
            if (mensaje == "1")
            {

                ViewBag.mensaje = mensaje;
                return RedirectToAction("ProductosxCat", "Producto");
            }
            else
                ViewBag.mensaje = "Usuario o contraseña incorrectos";
            return View();
            //ViewBag.categorias = new SelectList(await getCategorias(), "CategoriaId", "nombre", reg.CategoriaId);
            //return View(await Task.Run(() => objE));

        }
    }
}

