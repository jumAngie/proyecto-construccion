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
using System.Text;

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
                ViewBag.Mensaje = HttpContext.Session.GetString("UsuarioMod");
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

        [HttpPost("AgregarRol")]
        public async Task<JsonResult> AgregarRol(int role_Id, int pant_Id)
        {
            var Usuario_Id = HttpContext.Session.GetInt32("UsuarioId");
            PantallasRolesViewModel pantallasRoles = new PantallasRolesViewModel();
            pantallasRoles.role_Id = role_Id;
            pantallasRoles.pant_Id = pant_Id;
            pantallasRoles.user_UsuCreacion = (int)Usuario_Id;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<PantallasRolesViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "RolPantallas/AgregarPantallaRol", pantallasRoles);

            if (response.IsSuccessStatusCode)
            {
                string res = await response.Content.ReadAsStringAsync();
                var respuestaX = JsonConvert.DeserializeObject<INSERTAPI>(res);
                var mensaje = respuestaX.message;
                var resultado = 1;
                return Json(resultado);
            }
            return Json(0);
        }


        [HttpPost("EliminarRol")]
        public async Task<JsonResult> EliminarRol(int role_Id, int pant_Id)
        {
            PantallasRolesViewModel pantallasRoles = new PantallasRolesViewModel();
            pantallasRoles.role_Id = role_Id;
            pantallasRoles.pant_Id = pant_Id;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<PantallasRolesViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "RolPantallas/EliminarPantallaRol", pantallasRoles);

            if (response.IsSuccessStatusCode)
            {
                string res = await response.Content.ReadAsStringAsync();
                var respuestaX = JsonConvert.DeserializeObject<INSERTAPI>(res);
                var mensaje = respuestaX.message;
                var resultado = 1;
                return Json(resultado);
            }
            return Json(0);
        }


        [HttpPost("/Roles/CargarDatos")]
        public async Task<IActionResult> EditarNameRol(int role_Id)
        {
            RolesViewModel rolesViewModel = new RolesViewModel();
            rolesViewModel.role_Id = role_Id;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(builder.GetSection("ApiSettings:baseUrl").Value + "Rol/CargarDatosRoles", rolesViewModel);
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

        [HttpPost]
        public async Task<IActionResult> Update(RolesViewModel rolesViewModel)
        {
            var Usuario_Id = HttpContext.Session.GetInt32("UsuarioId");
            rolesViewModel.role_UsuModificacion = Usuario_Id;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<RolesViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "Rol/Update", rolesViewModel);

            if (response.IsSuccessStatusCode)
            {
                string res = await response.Content.ReadAsStringAsync();
                var respuestaX = JsonConvert.DeserializeObject<INSERTAPI>(res);
                var mensaje = respuestaX.message;
                HttpContext.Session.SetString("UsuarioMod", mensaje);
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Delete(RolesViewModel rolesViewModel)
        {
            var Usuario_Id = HttpContext.Session.GetInt32("UsuarioId");
            rolesViewModel.role_UsuModificacion = Usuario_Id;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<RolesViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "Rol/Delete", rolesViewModel);

            if (response.IsSuccessStatusCode)
            {
                string res = await response.Content.ReadAsStringAsync();
                var respuestaX = JsonConvert.DeserializeObject<INSERTAPI>(res);
                var mensaje = respuestaX.message;
                HttpContext.Session.SetString("EliminarRol", mensaje);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
