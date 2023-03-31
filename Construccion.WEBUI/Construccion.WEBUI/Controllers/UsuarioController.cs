using Construccion.API.Models;
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
    public class UsuarioController : Controller
    {
        private readonly HttpClient _httpClient;

        public UsuarioController(HttpClient httpClient)
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
                HttpResponseMessage response = await _httpClient.GetAsync(builder.GetSection("ApiSettings:baseUrl").Value + "Usuarios/List");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ResponseAPI<UsuarioViewModelLista>>(content);
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

        [HttpGet("/Usuario/CargarEmpleados")]

        public async Task<IActionResult> CargarEmpleados()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.GetAsync(builder.GetSection("ApiSettings:baseUrl").Value + "Usuarios/ListarUsuarioEmpleads");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseAPI<UsuarioViewModelLista>>(content);
                var res = result.data;
                return Json(res);
            }
            else
            {
                // manejar error
                return null;
            }
        }


        [HttpGet("/Usuario/CargarRoles")]

        public async Task<IActionResult> CargarRoles()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.GetAsync(builder.GetSection("ApiSettings:baseUrl").Value + "Rol/List");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseAPI<RolesViewModel>>(content);
                var res = result.data;
                return Json(res);
            }
            else
            {
                // manejar error
                return null;
            }
        }

        [HttpPost("InsertarUsuarios")]
        public async Task<IActionResult> InsertarUsuarios(int role_Id, int empe_Id,  bool user_EsAdmin, string user_Contrasena, string user_NombreUsuario)
        { 
            var Usuario_Id = HttpContext.Session.GetInt32("UsuarioId");
            UsuarioViewModel usuarioViewModel = new UsuarioViewModel();
            usuarioViewModel.empe_Id = empe_Id;
            usuarioViewModel.role_Id = role_Id;
            usuarioViewModel.user_EsAdmin = user_EsAdmin;
            usuarioViewModel.user_Contrasena = user_Contrasena;
            usuarioViewModel.user_NombreUsuario = user_NombreUsuario;
            usuarioViewModel.user_UsuCreacion = (int)Usuario_Id;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<UsuarioViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "Usuarios/InsertarUsuario", usuarioViewModel);

            if (response.IsSuccessStatusCode)
            {
                string res = await response.Content.ReadAsStringAsync();
                var respuestaX = JsonConvert.DeserializeObject<INSERTAPI>(res);
                var mensaje = respuestaX.message;
                return Json(1);
            }
            return Json(0);
        }


        [HttpPost("/Usuario/CargarDatosUsuarios")]
        public async Task<IActionResult> CargarDatosUsuarios(int user_Id)
        {
            var Usuario_Id = HttpContext.Session.GetInt32("UsuarioId");
            UsuarioViewModel usuarioViewModel = new UsuarioViewModel();
            usuarioViewModel.user_Id = user_Id;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<UsuarioViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "Usuarios/CargarDatosUsuarios", usuarioViewModel);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseAPI<UsuarioViewModel>>(content);
                var res = result.data;
                return Json(res);
            }
            return Json(0);
        }

        [HttpPost("EditarUsuarios")]
        public async Task<IActionResult> EditarUsuarios(int user_Id,int role_Id, int empe_Id, bool user_EsAdmin, string user_NombreUsuario)
        {
            var Usuario_Id = HttpContext.Session.GetInt32("UsuarioId");
            UsuarioViewModel usuarioViewModel = new UsuarioViewModel();
            usuarioViewModel.user_Id = user_Id;
            usuarioViewModel.empe_Id = empe_Id;
            usuarioViewModel.role_Id = role_Id;
            usuarioViewModel.user_EsAdmin = user_EsAdmin;         
            usuarioViewModel.user_NombreUsuario = user_NombreUsuario;
            usuarioViewModel.user_UsuModificacion = (int)Usuario_Id;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<UsuarioViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "Usuarios/UpdateUsuario", usuarioViewModel);

            if (response.IsSuccessStatusCode)
            {
                string res = await response.Content.ReadAsStringAsync();
                var respuestaX = JsonConvert.DeserializeObject<INSERTAPI>(res);
                var mensaje = respuestaX.message;
                return RedirectToAction("Index","Usuario");
            }
            return Json(0);
        }

        //[HttpPost("/Usuario/ExisteUsuario")]
        //public async Task<IActionResult> ExisteUsuario(string user_NombreUsuario)
        //{
        //    var Usuario_Id = HttpContext.Session.GetInt32("UsuarioId");
        //    UsuarioViewModel usuarioViewModel = new UsuarioViewModel();
        //    usuarioViewModel.user_NombreUsuario = user_NombreUsuario;
        //    var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        //    HttpResponseMessage response = await _httpClient.PostAsJsonAsync<UsuarioViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "Usuarios/ExisteUsuario", usuarioViewModel);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        string content = await response.Content.ReadAsStringAsync();
        //        var result = JsonConvert.DeserializeObject<INSERTAPI>(content);
        //        var res = result.message;
        //        if (res == "Operacion realizada con exito")
        //        {
        //            return Json(1);
        //        }
        //        else
        //        {
        //            return Json(0);
        //        }

        //    }
        //    return Json(0);
        //}


        [HttpPost("/Usuario/EliminarUsuario")]
        public async Task<IActionResult> EliminarUsuario(int user_Id)
        {
            var Usuario_Id = HttpContext.Session.GetInt32("UsuarioId");
            UsuarioViewModel usuarioViewModel = new UsuarioViewModel();
            usuarioViewModel.user_Id = user_Id;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<UsuarioViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "Usuarios/EliminarUsuario", usuarioViewModel);
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
