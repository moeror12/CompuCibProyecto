using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProyectoCompuCibVista.Models;

namespace ProyectoCompuCibVista.Controllers
{
    public class ContactoController : Controller
    {
        public async Task<IActionResult> ListarContactos()
        {
            return View(await getContactos());
        }
        async Task<List<Contacto>> getContactos()
        {
            List<Contacto> temporal = new List<Contacto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/api/Contacto/getContactos");
                HttpResponseMessage mensaje = await client.GetAsync("getContactos");
                string cadena = await mensaje.Content.ReadAsStringAsync();

                temporal = JsonConvert.DeserializeObject<List<Contacto>>(cadena).Select(
                    s => new Contacto
                    {
                        IdContacta = s.IdContacta,
                        nombreapellido = s.nombreapellido,
                        correo = s.correo,
                        asunto = s.asunto,
                        mensaje = s.mensaje,
                    }).ToList();
            }
            return temporal;
        }
        [HttpGet]
        public ActionResult eliminarContacto(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://www.tienditacompucib.somee.com/");
            var request = clienteHttp.DeleteAsync("api/Contacto/eliminarContacto/" + id).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var estado = JsonConvert.DeserializeObject<bool>(resultString);
                if (estado)
                {
                    return RedirectToAction("ListarContactos");
                }
            }
            return View();
        }
    }
}
