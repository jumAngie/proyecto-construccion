using Construccion.API.Models;
using Construccion.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Construccion.WEBUI.Controllers
{
    public class ConstruccionesController : Controller
    {
        private readonly HttpClient _httpClient;

        public ConstruccionesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/Construcciones/Listar")]
        public async Task<IActionResult> Listado()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.GetAsync(builder.GetSection("ApiSettings:baseUrl").Value + "Construcciones/List");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseAPI<ConstruccionesViewModel>>(content);
                var res = result.data;
                return Json(res);
            }
            else
            {
                // manejar error
                return null;
            }
        }


        [HttpPost("/Construcciones/EmpleadosListar")]
        public async Task<JsonResult> RolesPantalla(int cons_Id)
        {
            ConstruccionesViewModel construccionesViewModel = new ConstruccionesViewModel();
            construccionesViewModel. = role_Id;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<PantallasRolesViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "Rol/RolPantallaPorIdRol", pantallas);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseAPI<PantallasRolesViewModel>>(content);
                var res = result.data;
                return Json(new { success = true, res });
            }
            else
            {
                // manejar error
                return null;
            }
        }
    }
}
