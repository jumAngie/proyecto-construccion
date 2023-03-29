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

        [HttpPost("/Construcciones/InsertarConstruccion")]
        public async Task<JsonResult> Create(string cons_Proyecto, string cons_ProyectoDescripcion, string muni_id, string cons_Direccion,DateTime cons_FechaInicio, DateTime cons_FechaFin)
        {
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            ConstruccionesViewModel construccionesViewModel1 = new ConstruccionesViewModel();
            construccionesViewModel1.cons_Proyecto = cons_Proyecto;
            construccionesViewModel1.cons_ProyectoDescripcion = cons_ProyectoDescripcion;
            construccionesViewModel1.muni_Id = muni_id;
            construccionesViewModel1.cons_Direccion = cons_Direccion;
            construccionesViewModel1.cons_FechaInicio = cons_FechaInicio;
            construccionesViewModel1.cons_FechaFin = cons_FechaFin;
            construccionesViewModel1.user_UsuCreacion = usuarioId;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<ConstruccionesViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "Rol/Insert", construccionesViewModel1);

            if (response.IsSuccessStatusCode)
            {
                string res = await response.Content.ReadAsStringAsync();
                var respuestaX = JsonConvert.DeserializeObject<INSERTAPI>(res);
                var mensaje = respuestaX.message;
                int data = respuestaX.code;
                return Json(data);
            }
            return Json(0);
        }

    }
}
