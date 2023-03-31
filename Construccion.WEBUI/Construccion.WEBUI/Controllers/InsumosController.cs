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
    public class InsumosController : Controller
    {
        private readonly HttpClient _httpClient;

        public InsumosController(HttpClient httpClient)
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
                HttpResponseMessage response = await _httpClient.GetAsync(builder.GetSection("ApiSettings:baseUrl").Value + "Insumos/List");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ResponseAPI<InsumosViewModel>>(content);
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
        public async Task<IActionResult> Create(InsumosViewModel insumosView, string insm_Descripcion, int unim_Id)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            insumosView.user_UsuCreacion = (int)HttpContext.Session.GetInt32("UsuarioId");
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<InsumosViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "Insumos/Insert", insumosView);

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


        [HttpPost]
        public async Task<IActionResult> Edit(InsumosViewModel insumos)
        {

            insumos.user_UsuModificacion = (int)HttpContext.Session.GetInt32("UsuarioId");
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var proveedorJson = new StringContent(JsonConvert.SerializeObject(insumos), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(builder.GetSection("ApiSettings:baseUrl").Value + "Insumos/Update", proveedorJson);

            

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var respuesta = JsonConvert.DeserializeObject<INSERTAPI>(content);

                ViewBag.Success = respuesta.message;

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


        [HttpGet("/Insumos/CargarUnidadesMedida")]

        public async Task<IActionResult> CargarUnidadesMedida()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.GetAsync(builder.GetSection("ApiSettings:baseUrl").Value + "Insumos/ListarUnidadesdeMedida");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var unidadesMedida = JsonConvert.DeserializeObject<List<DDLUnidadesMedida>>(content);
                return Json(unidadesMedida);
            }
            else
            {
                // manejar error
                return null;
            }
        }
    }
}
