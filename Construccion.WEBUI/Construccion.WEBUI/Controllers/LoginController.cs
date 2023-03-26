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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ValidarSesion(UsuarioViewModel usuarioViewModel)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<UsuarioViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "Usuarios/Login/Index", usuarioViewModel);

            if (response.IsSuccessStatusCode)
            {
                string res = await response.Content.ReadAsStringAsync();
                var respuestaX = JsonConvert.DeserializeObject<ResponseAPI<UsuarioViewModel>>(res);
                int UsuarioId = 0;
                var usuario = string.Empty;
                var empleado = string.Empty;
                string admin = string.Empty;
                foreach (var item in respuestaX.data)
                {
                     UsuarioId = item.user_Id;
                     usuario   = item.user_NombreUsuario;
                     empleado  = item.empl_Nombre;
                     admin     = (item.user_EsAdmin).ToString();
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
                return RedirectToAction("Index","Home");
            }
            return View();
        }
    }
}
