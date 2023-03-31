using Construccion.WEBUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Construccion.WEBUI.Controllers
{
    public class IncidenciasController : Controller
    {
        private readonly HttpClient _httpClient;

        public IncidenciasController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Index()
        {
            var UserName = HttpContext.Session.GetString("user_Nombre");
            if (UserName != "" && UserName != null)
            {
                ViewBag.Admin = HttpContext.Session.GetString("user_EsAdmin");
                ViewBag.Nombre = HttpContext.Session.GetString("empl_Nombre");
                ViewBag.Mensaje = HttpContext.Session.GetString("Mensaje");
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.GetAsync(builder.GetSection("ApiSettings:baseUrl").Value + "Incidencias/List");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseAPI<IncidenciasViewModel>>(content);
                var res = result.data;
                return View(res);
            }
            else
            {
                // manejar error
                return null;
            }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(IncidenciasViewModel incidenciasView, string inci_Descripcion, int cons_Id)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            incidenciasView.user_UsuCreacion = HttpContext.Session.GetInt32("UsuarioId");
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<IncidenciasViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "Incidencias/Insert", incidenciasView);

            if (response.IsSuccessStatusCode)
            {
                string res = await response.Content.ReadAsStringAsync();
                var respuestaX = JsonConvert.DeserializeObject<INSERTAPI>(res);
                var mensaje = respuestaX.message;
                HttpContext.Session.SetString("NombreUsuario", mensaje);
                return RedirectToAction("Index");
            }
            return View();
        }




        [HttpGet("/Incidencias/ListarConstrucciones")]

        public async Task<IActionResult> ListarConstrucciones()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.GetAsync(builder.GetSection("ApiSettings:baseUrl").Value + "Incidencias/ListadoConstrucciones");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var construcciones = JsonConvert.DeserializeObject<List<ListarConstrucciones>>(content);
                return Json(construcciones);
            }
            else
            {
                // manejar error
                return null;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(IncidenciasViewModel incidencias)
        {
            incidencias.user_UsuModificacion = (int)HttpContext.Session.GetInt32("UsuarioId");
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var proveedorJson = new StringContent(JsonConvert.SerializeObject(incidencias), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(builder.GetSection("ApiSettings:baseUrl").Value + "Incidencias/Update", proveedorJson);


            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var respuesta = JsonConvert.DeserializeObject<INSERTAPI>(content);

                ViewBag.Success = respuesta.message;

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


        [HttpPost("/Incidencias/EliminarIncidencias")]
        public async Task<IActionResult> EliminarUsuario(int inci_Id)
        {
            var Usuario_Id = HttpContext.Session.GetInt32("UsuarioId");
            IncidenciasViewModel incidenciasView = new IncidenciasViewModel();
            incidenciasView.user_UsuModificacion = Usuario_Id;
            incidenciasView.inci_Id = inci_Id;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<IncidenciasViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "Incidencias/EliminarIncidencia", incidenciasView);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<INSERTAPI>(content);
                var res = result.message;
                return Json(1);
            }
            return Json(0);
        }
    }
}
