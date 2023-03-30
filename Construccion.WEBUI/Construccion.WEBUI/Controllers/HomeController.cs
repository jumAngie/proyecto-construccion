using Construccion.WEBUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
namespace Construccion.WEBUI.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {
            var UserName = HttpContext.Session.GetString("user_Nombre");
            if (UserName  != "" && UserName != null)
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

        [HttpGet]
        public async Task<IActionResult> EmpleadosChart()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.GetAsync(builder.GetSection("ApiSettings:baseUrl").Value + "Empleados/EmpleadosPorSexo");
            if (response.IsSuccessStatusCode)
            {
                string res = await response.Content.ReadAsStringAsync();
                var respuestaX = JsonConvert.DeserializeObject<EmpleadosChartViewModel>(res);
                return Json(respuestaX);

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PantallasMenu(PantallasViewModel pantallasViewModel)
         {
            var EsAdmin = HttpContext.Session.GetString("user_EsAdmin");
            bool esAdmin = false;
            if(EsAdmin == "Admin")
            {
                esAdmin = true;
            }
            else
            {
                esAdmin = false;
            }
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            pantallasViewModel.role_Id = (int)HttpContext.Session.GetInt32("rol_Id") ;
            pantallasViewModel.esAdmin = esAdmin;
            
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<PantallasViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "RolPantallas/PantallasPorMenu", pantallasViewModel);

            if (response.IsSuccessStatusCode)
            {
                string res = await response.Content.ReadAsStringAsync();
                var respuestaX = JsonConvert.DeserializeObject<ResponseAPI<PantallasViewModel>>(res);
                var pantallas = respuestaX.data;
                return Json(pantallas.ToList());
            }
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
