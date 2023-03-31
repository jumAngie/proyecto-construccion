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
using System.Threading.Tasks;

namespace Construccion.WEBUI.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly HttpClient _httpClient;

        public EmpleadosController(HttpClient httpClient)
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
            HttpResponseMessage response = await _httpClient.GetAsync(builder.GetSection("ApiSettings:baseUrl").Value + "Empleados/List");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseAPI<EmpleadosViewModel>>(content);
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

        [HttpGet]
        public IActionResult Create()
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


        [HttpPost]
        public async Task<IActionResult> Create(EmpleadosViewModel empleados)
        {
            if (ModelState.IsValid)
            {
                int? usuarioId = HttpContext.Session.GetInt32("UsuarioId");
                empleados.user_IdCreacion = usuarioId;
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync<EmpleadosViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "Empleados/Insert", empleados);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<INSERTAPI>(content);
                    return RedirectToAction("Index");
                }
                else
                {
                    // manejar error pantalla
                    return null;
                }
            }
            else
            {
                return View(empleados);
            }

        }

        [HttpPost("/Empleados/EliminarEmpleado")]
        public async Task<IActionResult> EliminarUsuario(int empl_Id)
        {
            var Usuario_Id = HttpContext.Session.GetInt32("UsuarioId");
            EmpleadosViewModel emple = new EmpleadosViewModel();
            emple.user_IdModificacion = Usuario_Id;
            emple.empl_Id = empl_Id;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<EmpleadosViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "Empleados/EliminarEmpleados", emple);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<INSERTAPI>(content);
                var res = result.message;
                return Json(1);
            }
            return Json(0);
        }



        [HttpGet("/Empleados/ListarEstadosCiviles")]
        public async Task<IActionResult> ListarEstadosCiviles()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.GetAsync(builder.GetSection("ApiSettings:baseUrl").Value + "Empleados/ListarEstadosCiviles");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<DDLEstadosCiviles>>(content);
                return Json(result);
            }
            else
            {
                // manejar error
                return null;
            }
        }

        [HttpGet("/Empleados/ListarCargos")]
        public async Task<IActionResult> ListarCargos()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.GetAsync(builder.GetSection("ApiSettings:baseUrl").Value + "Empleados/ListarCargos");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<DDLCargos>>(content);
                return Json(result);
            }
            else
            {
                // manejar error
                return null;
            }
        }
    }
}
