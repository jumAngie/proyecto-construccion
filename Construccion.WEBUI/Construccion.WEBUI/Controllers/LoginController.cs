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
    public class LoginController : Controller
    {
        private readonly HttpClient _httpClient;

        public LoginController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public IActionResult Index()
        {
            string Sesion = HttpContext.Session.GetString("InicioSesion");
            if (Sesion == "1")
            {
                ViewBag.User = HttpContext.Session.GetString("User");
                ViewBag.Contra = HttpContext.Session.GetString("contra");
                ModelState.AddModelError("ErrorSesion", "Usuario o contraseña incorrecta");
                ModelState.AddModelError("ErrorSesion1", "Usuario incorrecto");
                ModelState.AddModelError("ErrorSesion2", "contraseña incorrecta");
                ViewBag.Sesion = "Sesion";
                return View();
            }
            if (Sesion == "2")
            {
                ModelState.AddModelError("ErrorSesion", "El campo de usuario y contraseña son requeridos");
                ModelState.AddModelError("ErrorSesion1", "campo requerido");
                ModelState.AddModelError("ErrorSesion2", "campo requerido");
                ViewBag.Sesion = "Sesion";
                return View();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ValidarSesion(UsuarioViewModel usuarioViewModel)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<UsuarioViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "Usuarios/Login/Index", usuarioViewModel);
            HttpContext.Session.SetString("InicioSesion", "");
            if ((usuarioViewModel.user_Contrasena != null) && ( usuarioViewModel.user_NombreUsuario != null))
            {
                if (response.IsSuccessStatusCode)
                {
                    string res = await response.Content.ReadAsStringAsync();
                    var respuestaX = JsonConvert.DeserializeObject<ResponseAPI<UsuarioViewModel>>(res);
                    if (respuestaX.data.Count > 0)
                    {
                        int UsuarioId = 0;
                        var usuario = string.Empty;
                        var empleado = string.Empty;
                        string admin = string.Empty;
                        foreach (var item in respuestaX.data)
                        {
                            UsuarioId = item.user_Id;
                            usuario = item.user_NombreUsuario;
                            empleado = item.empl_Nombre;
                            admin = (item.user_EsAdmin).ToString();
                        }
                        var mensaje = respuestaX.message;
                        string resultado = string.Empty;
                        if (admin == "True")
                        {
                            resultado = "Admin";
                        }
                        else
                        {
                            resultado = "No administrador";
                        }
                        HttpContext.Session.SetString("user_EsAdmin", resultado);
                        HttpContext.Session.SetString("empl_Nombre", empleado);
                        HttpContext.Session.SetString("user_Nombre", usuario);
                        HttpContext.Session.SetInt32("UsuarioId", UsuarioId);
                        HttpContext.Session.SetString("Mensaje", mensaje);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        HttpContext.Session.SetString("User", usuarioViewModel.user_NombreUsuario);
                        HttpContext.Session.SetString("contra", usuarioViewModel.user_Contrasena);
                        HttpContext.Session.SetString("Com", "12");
                        HttpContext.Session.SetString("InicioSesion", "1");
                        return RedirectToAction("Index", "Login");
                    }
                }               
            }
            else
            {
                HttpContext.Session.SetString("InicioSesion", "2");
                return RedirectToAction("Index", "Login");  
            }
            return View();
        }

        [HttpPost("/Login/Cambiar")]
        public async Task<JsonResult> CambiarPassword(UsuarioViewModel usuarioViewModel)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<UsuarioViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "", usuarioViewModel);
            return Json("hola");
        }

        public ActionResult CerrarSesion()
        {
            HttpContext.Session.SetString("user_Nombre","");
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }

    }
}
