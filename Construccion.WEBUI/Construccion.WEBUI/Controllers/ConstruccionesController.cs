using Construccion.API.Models;
using Construccion.WEBUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
            var UserName = HttpContext.Session.GetString("user_Nombre");
            if (UserName != "" && UserName != null)
            {
                ViewBag.Admin = HttpContext.Session.GetString("user_EsAdmin");
                ViewBag.Nombre = HttpContext.Session.GetString("empl_Nombre");
                ViewBag.Mensaje = HttpContext.Session.GetString("Mensaje");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
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

        [HttpPost("/Construcciones/ListarInsumos")]
        public async Task<JsonResult> ListarInsumosPorIdConstruccion(int cons_Id)
        {
            InsumosPorConstruccionViewModel insumosPorConstruccionViewModel = new InsumosPorConstruccionViewModel();
            insumosPorConstruccionViewModel.cons_Id = cons_Id;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<InsumosPorConstruccionViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "InsumosConstruccion/InsumosPorIdConstruccion", insumosPorConstruccionViewModel);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseAPI<InsumosPorConstruccionViewModel>>(content);
                var res = result.data;
                return Json(res);
            }
            else
            {
                // manejar error
                return null;
            }
        }


        [HttpGet("/Construcciones/ListarDepartamentos")]
        public async Task<IActionResult> ListarDepartamentos()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.GetAsync(builder.GetSection("ApiSettings:baseUrl").Value + "Departamentos/ListarDepartamentos");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseAPI<DepartamentosViewModel>>(content);
                var res = result.data;
                return Json(res);
            }
            else
            {
                // manejar error
                return null;
            }
        }

        [HttpPost("/Construcciones/ListarMunicipiosPorIdDepartamento")]
        public async Task<IActionResult> ListarMunicipiosPorIdDepartamento(string depa_Id)
        {
            MunicipiosViewModel municipiosViewModel = new MunicipiosViewModel();
            municipiosViewModel.depa_Id = depa_Id;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<MunicipiosViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "Municipios/ListarMunicipiosPorIdDepartamento", municipiosViewModel);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseAPI<MunicipiosViewModel>>(content);
                var res = result.data;
                return Json(res);
            }
            else
            {
                // manejar error
                return null;
            }
        }

    }
}
