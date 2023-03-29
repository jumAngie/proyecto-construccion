using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Construccion.API.Models;
using Construccion.WEBUI.Models;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Construccion.WEBUI.Controllers
{
    public class RolesController : Controller
    {
        private readonly HttpClient _httpClient;

        public RolesController(HttpClient httpClient)
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

        [HttpPost("/Roles/Listar")]
        public async Task<IActionResult> Listado()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.GetAsync(builder.GetSection("ApiSettings:baseUrl").Value + "Rol/List");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseAPI<RolesViewModel>>(content);
                var res = result.data;
                return Json(res.ToList());
            }
            else
            {
                // manejar error
                return null;
            }
        }

        [HttpPost("/Roles/RolesPantalla")]
        public async Task<JsonResult> RolesPantalla(int role_Id)
        {
            PantallasRolesViewModel pantallas = new PantallasRolesViewModel();
            pantallas.role_Id = role_Id;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RolesViewModel rolesViewModel)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<RolesViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "Rol/Insert", rolesViewModel);

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
    }
}
