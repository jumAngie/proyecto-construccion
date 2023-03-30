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
    public class ClientesController : Controller
    {
        private readonly HttpClient _httpClient;

        public ClientesController(HttpClient httpClient)
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
                HttpResponseMessage response = await _httpClient.GetAsync(builder.GetSection("ApiSettings:baseUrl").Value + "Clientes/List");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ResponseAPI<ClientesViewModel>>(content);
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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientesViewModel clientesView)
        {
            if(ModelState.IsValid)
            {
                int? usuarioId = HttpContext.Session.GetInt32("UsuarioId");
                clientesView.user_IdCreacion = usuarioId;
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync<ClientesViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "Clientes/Insert", clientesView);

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
                return View(clientesView);
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int clie_Id)
        {
            ClientesViewModel clientesView = new ClientesViewModel();
            clientesView.clie_Id = clie_Id;

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<ClientesViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "Clientes/Find", clientesView);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseAPI<ClientesViewModel>>(content);
                var res = result.data;
                return Json(res);
            }
            else
            {
                // manejar error
                return null;
            }
        }

        [HttpGet("/Clientes/ListarDepartamentos")]
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

        [HttpPost("/Clientes/ListarMunicipiosPorIdDepartamento")]
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
