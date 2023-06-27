using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ProyectoCompuCibVista.Database;
using ProyectoCompuCibVista.Models;
using System.Data.SqlClient;
using System.Data;
using System.Net.Http.Formatting;
using System.Security.Cryptography;
using System.Text;

namespace ProyectoCompuCibVista.Controllers
{
    public class ReclamoController : Controller
    {
        async Task<List<Reclamo>> getReclamos()
        {
            List<Reclamo> temporal = new List<Reclamo>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/api/Reclamo/getReclamos");
                HttpResponseMessage mensaje = await client.GetAsync("getReclamos");
                string cadena = await mensaje.Content.ReadAsStringAsync();

                temporal = JsonConvert.DeserializeObject<List<Reclamo>>(cadena).Select(
                    s => new Reclamo
                    {
                        IdReclamo = s.IdReclamo,
                        descripcion = s.descripcion,
                        DiaReclamo = s.DiaReclamo,
                        IdVenta = s.IdVenta,
                    }).ToList();
            }
            return temporal;
        }

        [HttpGet]
        async Task<List<Reclamo>> getReclamo(int rId)
        {
            List<Reclamo> temporal = new List<Reclamo>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/api/Reclamo/obtenerReclamo/" + rId);
                HttpResponseMessage mensaje = await client.GetAsync("getReclamos");
                string cadena = await mensaje.Content.ReadAsStringAsync();

                temporal = JsonConvert.DeserializeObject<List<Reclamo>>(cadena).Select(
                    s => new Reclamo
                    {
                        IdReclamo = s.IdReclamo,
                        descripcion = s.descripcion,
                        DiaReclamo = s.DiaReclamo,
                        IdVenta = s.IdVenta,
                    }).ToList();
            }
            return temporal;
        }
        [HttpGet]
        async Task<List<ReclamoN>> getNumeroReclamos()
        {
            List<ReclamoN> temporal = new List<ReclamoN>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/api/Reclamo/numeroReclamos");
                HttpResponseMessage mensaje = await client.GetAsync("numeroReclamos");
                string cadena = await mensaje.Content.ReadAsStringAsync();

                temporal = JsonConvert.DeserializeObject<List<ReclamoN>>(cadena).Select(
                    s => new ReclamoN
                    {
                        numerosReclamos = s.numerosReclamos
                    }).ToList();
            }
            return temporal;
        }

        [HttpGet]
        async Task<List<Reclamo>> getReclamoxCorreo(string correo)
        {
            List<Reclamo> temporal = new List<Reclamo>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/");
                HttpResponseMessage mensaje = await client.GetAsync("api/Reclamo/obtenerReclamoxCorreo/" + correo);
                string cadena = await mensaje.Content.ReadAsStringAsync();

                temporal = JsonConvert.DeserializeObject<List<Reclamo>>(cadena).Select(
                    s => new Reclamo
                    {
                        IdReclamo = s.IdReclamo,
                        descripcion = s.descripcion,
                        DiaReclamo = s.DiaReclamo,
                        IdVenta = s.IdVenta,
                    }).ToList();
            }
            return temporal;
        }

        public async Task<IActionResult> ListaReclamos()
        {
            return View(await getReclamos());
        }
        public async Task<IActionResult> ListaReclamosN()
        {
            return View(await getNumeroReclamos());
        }
        public async Task<IActionResult> Create()
        {
            return View(await Task.Run(() => new Reclamo()));
        }

        public async Task<IActionResult> ReclamosxCorreo(string correo)
        {
            ViewBag.correo = correo;
            return View(await getReclamoxCorreo(correo));
        }
        [HttpPost]
        public async Task<IActionResult> Create(Reclamo reg)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/api/Reclamo/createReclamo");
                StringContent contenido = new StringContent(JsonConvert.SerializeObject(reg), Encoding.UTF8, "application/json");
                HttpResponseMessage msg = await client.PostAsync("createReclamo", contenido);
                mensaje = await msg.Content.ReadAsStringAsync();

            }
            if (mensaje == "1")
            {
                ViewBag.mensaje = "El Reclamo se Creó Correctamente!";
                TempData["mensaje"] = "Reclamo registrado correctamente";
                ViewBag.code = "1";
                return View(await Task.Run(() => reg));
            }
            else if (mensaje == "2")
            {
                ViewBag.mensaje = "El Reclamo ya existe!";
                ViewBag.code = "2";
                return View(await Task.Run(() => reg));
            }
            else
            {
                ViewBag.mensaje = "Error al Crear el Reclamo";
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
            var request = clienteHttp.GetAsync("api/Reclamo/obtenerReclamo/" + id).Result;

            var resultString = request.Content.ReadAsStringAsync().Result;
            var objE = JsonConvert.DeserializeObject<Reclamo>(resultString);
            return View(objE);
        }
        [HttpPost]
        public ActionResult Edit(Reclamo objE)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/");
            var request = clienteHttp.PutAsync("/api/Reclamo/UpdateReclamo", objE, new
            JsonMediaTypeFormatter()).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var estado = JsonConvert.DeserializeObject<int>(resultString);
                if (estado == 1)
                {
                    ViewBag.mensaje = estado + " Reclamo actualizado correctamente..!!";
                    ViewBag.code = "1";
                    return View(objE);
                }
                else
                {
                    ViewBag.mensaje = "Error al actualizar el Reclamo";
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
            var request = clienteHttp.GetAsync("api/Reclamo/obtenerReclamo/" + id).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var objE = JsonConvert.DeserializeObject<Reclamo>(resultString);
                return View(objE);
            }

            return View();
        }
        [HttpGet]
        public ActionResult eliminarReclamo(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/");
            var request = clienteHttp.DeleteAsync("api/Reclamo/eliminarReclamo/" + id).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var estado = JsonConvert.DeserializeObject<bool>(resultString);
                if (estado)
                {
                    return RedirectToAction("ReclamosxCorreo");
                }
            }
            return View();
        }

    }
}
