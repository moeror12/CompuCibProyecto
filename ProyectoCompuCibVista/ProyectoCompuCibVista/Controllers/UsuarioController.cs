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
    public class UsuarioController : Controller
    {

        async Task<List<Usuario>> getUsuarios()
        {
            List<Usuario> temporal = new List<Usuario>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/api/Usuario/getUsuario");
                HttpResponseMessage mensaje = await client.GetAsync("getUsuario");
                string cadena = await mensaje.Content.ReadAsStringAsync();

                temporal = JsonConvert.DeserializeObject<List<Usuario>>(cadena).Select(
                    s => new Usuario
                    {
                        UsuarioId = s.UsuarioId,
                        CodigoUsuario = s.CodigoUsuario,
                        Nombre = s.Nombre,
                        Apellido = s.Apellido,
                        Correo = s.Correo,
                        Direccion = s.Direccion,
                        Telefono = s.Telefono,
                        Password = s.Password,
                        TipoUsuarioId = s.TipoUsuarioId,
                    }).ToList();
            }
            return temporal;
        }
        public async Task<IActionResult> ListarEmpleado()
        {
            return View(await getUsuarios());
        }
        public async Task<IActionResult> Create()
        {
            return View(await Task.Run(() => new Usuario()));
        }
        [HttpPost]
        public async Task<IActionResult> Create(Usuario reg)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/api/Usuario/createUsuario");
                StringContent contenido = new StringContent(JsonConvert.SerializeObject(reg), Encoding.UTF8, "application/json");
                HttpResponseMessage msg = await client.PostAsync("createUsuario", contenido);
                mensaje = await msg.Content.ReadAsStringAsync();

            }
            ViewBag.mensaje = mensaje;
            //ViewBag.categorias = new SelectList(await getCategorias(), "CategoriaId", "nombre", reg.CategoriaId);
            return View(await Task.Run(() => reg));
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/");
            var request = clienteHttp.GetAsync("api/Usuario/obtenerUsuario/" + id).Result;

            var resultString = request.Content.ReadAsStringAsync().Result;
            var objE = JsonConvert.DeserializeObject<Usuario>(resultString);
            return View(objE);
        }
        [HttpPost]
        public ActionResult Edit(Usuario objE)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/");
            var request = clienteHttp.PutAsync("/api/Usuario/UpdateUsuario", objE, new
            JsonMediaTypeFormatter()).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var estado = JsonConvert.DeserializeObject<int>(resultString);
                if (estado == 1)
                {
                    ViewBag.mensaje = estado + " Usuario actualizado correctamente..!!";
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
            var request = clienteHttp.GetAsync("api/Usuario/obtenerUsuario/" + id).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var objE = JsonConvert.DeserializeObject<Usuario>(resultString);
                return View(objE);
            }

            return View();
        }
        [HttpGet]
        public ActionResult eliminarUsuario(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/");
            var request = clienteHttp.DeleteAsync("api/Usuario/eliminarUsuario/" + id).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var estado = JsonConvert.DeserializeObject<bool>(resultString);
                if (estado)
                {
                    return RedirectToAction("ListarEmpleado");
                }
            }
            return View();
        }
    }
}
