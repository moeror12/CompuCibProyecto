using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProyectoCompuCibVista.Models;
using System.Net.Http.Formatting;
using System.Text;

namespace ProyectoCompuCibVista.Controllers
{
    public class VentaController : Controller
    {
        async Task<List<Venta>> getVentas()
        {
            List<Venta> temporal = new List<Venta>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/api/Venta/");
                HttpResponseMessage mensaje = await client.GetAsync("getVentas");
                string cadena = await mensaje.Content.ReadAsStringAsync();

                temporal = JsonConvert.DeserializeObject<List<Venta>>(cadena).Select(
                    s => new Venta
                    {
                        VentaId = s.VentaId,
                        name = s.name,
                        lastName = s.lastName,
                        address = s.address,
                        landmark = s.landmark,
                        district = s.district,
                        phoneNumber = s.phoneNumber,
                        paymentMethod = s.paymentMethod,
                        IdOrden = s.IdOrden,
                        DiaVenta = s.DiaVenta,
                    }).ToList();
            }
            return temporal;
        }
        public async Task<IActionResult> ListarVenta()
        {
            return View(await getVentas());
        }
        //public async Task<IActionResult> Create()
        //{
        //    return View(await Task.Run(() => new Usuario()));
        //}
        //[HttpPost]
        //public async Task<IActionResult> Create(Usuario reg)
        //{
        //    string mensaje = "";
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:7258/api/Usuario/createUsuario");
        //        StringContent contenido = new StringContent(JsonConvert.SerializeObject(reg), Encoding.UTF8, "application/json");
        //        HttpResponseMessage msg = await client.PostAsync("createUsuario", contenido);
        //        mensaje = await msg.Content.ReadAsStringAsync();

        //    }
        //    ViewBag.mensaje = mensaje;
        //    //ViewBag.categorias = new SelectList(await getCategorias(), "CategoriaId", "nombre", reg.CategoriaId);
        //    return View(await Task.Run(() => reg));
        //}
        [HttpGet]
        public ActionResult Edit(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/");
            var request = clienteHttp.GetAsync("api/Venta/obtenerVenta/" + id).Result;

            var resultString = request.Content.ReadAsStringAsync().Result;
            var objE = JsonConvert.DeserializeObject<Venta>(resultString);
            return View(objE);
        }
        [HttpPost]
        public ActionResult Edit(Venta objE)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/");
            var request = clienteHttp.PutAsync("/api/Venta/updateVenta", objE, new
            JsonMediaTypeFormatter()).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var estado = JsonConvert.DeserializeObject<int>(resultString);
                if (estado == 1)
                {
                    ViewBag.mensaje = estado + " Venta actualizada correctamente..!!";
                    return View(objE);
                }
                return View(objE);
            }
            return View();
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/");
            var request = clienteHttp.GetAsync("api/Venta/obtenerVenta/" + id).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var objE = JsonConvert.DeserializeObject<Venta>(resultString);
                return View(objE);
            }

            return View();
        }
        [HttpGet]
        public ActionResult eliminarVenta(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/");
            var request = clienteHttp.DeleteAsync("api/Venta/eliminarVenta/" + id).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var estado = JsonConvert.DeserializeObject<bool>(resultString);
                if (estado)
                {
                    return RedirectToAction("ListarVenta");
                }
            }
            return View();
        }
    }
}
