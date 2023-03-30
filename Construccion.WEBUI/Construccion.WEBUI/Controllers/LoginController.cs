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
            HttpContext.Session.SetString("InicioSesion", "");
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
            string errores = HttpContext.Session.GetString("Cambiar");
            HttpContext.Session.SetString("Cambiar", "");
            if (errores == "1")
            {
                ViewBag.MensajeCambia = HttpContext.Session.GetString("MensajeCam");
                ViewBag.Cambiar = "Logrado";
                return View();
            }
            string Restablecer = HttpContext.Session.GetString("MensajeRes");
            HttpContext.Session.SetString("MensajeRes", "");
            if (Restablecer != "" && Restablecer != null)
            {
                ViewBag.MensajeRestablecer = Restablecer;
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
                        int role_Id;
                        string admin = string.Empty;
                        foreach (var item in respuestaX.data)
                        {
                            UsuarioId = item.user_Id;
                            usuario = item.user_NombreUsuario;
                            empleado = item.empl_Nombre;
                            role_Id = item.role_Id;
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
                        HttpContext.Session.SetInt32("role_Id", role_Id);
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

        [HttpGet]
        public IActionResult ResetPassword()
        {
            var UserName = HttpContext.Session.GetString("user_Nombre");
            if (UserName != "" && UserName != null)
            {
                string Restablecer = HttpContext.Session.GetString("Restablecer");
                HttpContext.Session.SetString("Restablecer", "");
                if (Restablecer == "1")
                {
                    ModelState.AddModelError("ErrorSesion", "Usuario o contraseña incorrectos");
                    ModelState.AddModelError("ErrorSesion1", "*");
                    ModelState.AddModelError("ErrorSesion2", "*");
                    ViewBag.user = HttpContext.Session.GetString("User");
                    ViewBag.contra = HttpContext.Session.GetString("contra");
                    ViewBag.newcontra = HttpContext.Session.GetString("NewContra");
                    ViewBag.contracon = HttpContext.Session.GetString("Confirm");
                    ViewBag.ResX = Restablecer;
                    return View();
                }
                if (Restablecer == "2")
                {
                    ViewBag.user3 = "";
                    ViewBag.contra3 = "";
                    ViewBag.newcontra3 = "";
                    ViewBag.contracon3 = "";
                    ViewBag.Res2 = Restablecer;
                    ViewBag.user3 = HttpContext.Session.GetString("User");
                    ViewBag.contra3 = HttpContext.Session.GetString("contra");
                    ViewBag.newcontra3 = HttpContext.Session.GetString("NewContra");
                    ViewBag.contracon3 = HttpContext.Session.GetString("Confirm");
                    if ((ViewBag.user3 == "" || ViewBag.user3 == null) && (ViewBag.contra3 == "" || ViewBag.contra3 == null) && (ViewBag.newcontra3 == "" || ViewBag.newcontra3 == null) && (ViewBag.contracon3 == "" || ViewBag.contracon3 == null))
                    {
                        ModelState.AddModelError("ErrorSesion", "Todos los campos son requeridos");
                        ModelState.AddModelError("ErrorSesion1", "*");
                        ModelState.AddModelError("ErrorSesion2", "*");
                        ModelState.AddModelError("ErrorSesion3", "*");
                        ModelState.AddModelError("ErrorSesion4", "*");
                        return View();
                    }
                    else
                    {
                        ModelState.AddModelError("ErrorSesion", " Algunos campos son requeridos");
                        if (ViewBag.user3 == "" || ViewBag.user3 == null)
                        {
                            ModelState.AddModelError("ErrorSesion1", "*");
                        }
                        if (ViewBag.contra3 == "" || ViewBag.contra3 == null)
                        {
                            ModelState.AddModelError("ErrorSesion2", "*");
                        }
                        if (ViewBag.newcontra3 == "" || ViewBag.newcontra3 == null)
                        {
                            ModelState.AddModelError("ErrorSesion3", "*");
                        }
                        if (ViewBag.contracon3 == "" || ViewBag.contracon3 == null)
                        {
                            ModelState.AddModelError("ErrorSesion4", "*");
                        }
                        return View();
                    }
                }
                if (Restablecer == "3")
                {
                    ModelState.AddModelError("ErrorSesion", "La nueva contraseña y la contraseña de confirmación no coinciden");
                    ModelState.AddModelError("ErrorSesion3", "*");
                    ModelState.AddModelError("ErrorSesion4", "*");
                    ViewBag.user2 = HttpContext.Session.GetString("User");
                    ViewBag.contra2 = HttpContext.Session.GetString("contra");
                    ViewBag.newcontra2 = HttpContext.Session.GetString("NewContra");
                    ViewBag.contracon2 = HttpContext.Session.GetString("Confirm");
                    ViewBag.Res3 = Restablecer;
                    return View();
                }
                if (Restablecer == "4")
                {
                    ViewBag.Error = "Error al realizar la operación";
                    return View();
                }
                if (Restablecer == "5")
                {
                    ViewBag.Error2 = "Error al realizar la operación";
                    return View();
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        [HttpPost]
        public async Task<IActionResult> ResetPassword(UsuarioViewModel usuarioViewModel, string NewPassword, string ConfirmPassword)
        {
            var UserName = HttpContext.Session.GetString("user_Nombre");
            if (UserName != "" && UserName != null)
            {
                if (usuarioViewModel.user_Contrasena != null && usuarioViewModel.user_NombreUsuario != null && (NewPassword != "" && NewPassword != null) && (ConfirmPassword != "" && ConfirmPassword != null))
                {
                    if (NewPassword == ConfirmPassword)
                    {
                        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                        HttpResponseMessage response = await _httpClient.PostAsJsonAsync<UsuarioViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "Usuarios/EvaluarUsuarioRestablecer", usuarioViewModel);
                        if (response.IsSuccessStatusCode)
                        {
                            string res = await response.Content.ReadAsStringAsync();
                            var respuestaX = JsonConvert.DeserializeObject<ResponseAPI<UsuarioViewModel>>(res);
                            if (respuestaX.data.Count > 0)
                            {
                                usuarioViewModel.user_Contrasena = NewPassword;
                                HttpResponseMessage response2 = await _httpClient.PostAsJsonAsync<UsuarioViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "Usuarios/Restablecer", (usuarioViewModel));
                                if (response2.IsSuccessStatusCode)
                                {
                                    var mensaje2 = "Operacion realizada con exito";
                                    HttpContext.Session.SetString("user_Nombre", "");
                                    HttpContext.Session.Clear();
                                    HttpContext.Session.SetString("MensajeRes", mensaje2);
                                    return RedirectToAction("Index", "Login");
                                }
                                else
                                {
                                    HttpContext.Session.SetString("Restablecer", "5");
                                    return RedirectToAction("ResetPassword", "Login");
                                }
                            }
                            else
                            {
                                HttpContext.Session.SetString("User", usuarioViewModel.user_NombreUsuario);
                                HttpContext.Session.SetString("contra", usuarioViewModel.user_Contrasena);
                                HttpContext.Session.SetString("NewContra", NewPassword);
                                HttpContext.Session.SetString("Confirm", ConfirmPassword);
                                HttpContext.Session.SetString("Restablecer", "1");
                                return RedirectToAction("ResetPassword", "Login");
                            }
                        }
                        else
                        {
                            HttpContext.Session.SetString("Restablecer", "4");
                            return RedirectToAction("ResetPassword", "Login");
                        }
                    }
                    else
                    {
                        HttpContext.Session.SetString("User", usuarioViewModel.user_NombreUsuario);
                        HttpContext.Session.SetString("contra", usuarioViewModel.user_Contrasena);
                        HttpContext.Session.SetString("NewContra", NewPassword);
                        HttpContext.Session.SetString("Confirm", ConfirmPassword);
                        HttpContext.Session.SetString("Restablecer", "3");
                        return RedirectToAction("ResetPassword", "Login");
                    }

                }
                else
                {
                    HttpContext.Session.SetString("User", string.Empty);
                    HttpContext.Session.SetString("contra", string.Empty);
                    HttpContext.Session.SetString("NewContra", string.Empty);
                    HttpContext.Session.SetString("Confirm",string.Empty);
                    if (usuarioViewModel.user_NombreUsuario != "" && usuarioViewModel.user_NombreUsuario != null)
                        HttpContext.Session.SetString("User", usuarioViewModel.user_NombreUsuario);

                    if (usuarioViewModel.user_Contrasena != "" && usuarioViewModel.user_Contrasena != null)
                        HttpContext.Session.SetString("contra", usuarioViewModel.user_Contrasena);

                    if (NewPassword != "" && NewPassword != null)
                        HttpContext.Session.SetString("NewContra", NewPassword);

                    if (ConfirmPassword != "" && ConfirmPassword != null)
                        HttpContext.Session.SetString("Confirm", ConfirmPassword);

                    HttpContext.Session.SetString("Restablecer", "2");
                    return RedirectToAction("ResetPassword", "Login");
                }
                
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }



        [HttpPost("/Login/Cambiar")]
        public async Task<JsonResult> CambiarPassword(UsuarioViewModel usuarioViewModel)
        {
            var errores = -1;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<UsuarioViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "Usuarios/Evaluar", usuarioViewModel);
            if ((usuarioViewModel.user_Contrasena != null) && (usuarioViewModel.user_NombreUsuario != null))
            {
                if (response.IsSuccessStatusCode)
                {
                    string res = await response.Content.ReadAsStringAsync();
                    var respuestaX = JsonConvert.DeserializeObject<ResponseAPI<UsuarioViewModel>>(res);
                    if (respuestaX.data.Count > 0)
                    {
                        HttpResponseMessage response2 = await _httpClient.PostAsJsonAsync<UsuarioViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "Usuarios/Update", usuarioViewModel);
                        if (response2.IsSuccessStatusCode)
                        {
                            var mensaje2 = "Operacion realizada con exito";
                            HttpContext.Session.SetString("MensajeCam", mensaje2);
                            HttpContext.Session.SetString("Cambiar", "1");
                            return Json(errores = 1);
                        }
                        else
                        {
                            HttpContext.Session.SetString("Cambiar", "2");
                            return Json(errores = 2);
                        }
                    }
                    else
                    {

                        return Json(errores = 3);
                    }
                }
                else
                {
                    return Json(errores = 4);
                }
            }
            else
            {
                return Json(errores = 5);
            }
        }

        public ActionResult CerrarSesion()
        {
            HttpContext.Session.SetString("user_Nombre","");
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }

    }
}
