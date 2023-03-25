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

namespace Construccion.WEBUI.Controllers
{
    public class RolesController : Controller
    {
        private readonly HttpClient _httpClient;

        public RolesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Index()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.GetAsync(builder.GetSection("ApiSettings:baseUrl").Value + "Rol/List");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<ResponseAPI<RolesViewModel>>(content);
                return View(result.data);
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
                ViewBag.Mensaje = mensaje;
                return RedirectToAction("Index");

            }
            return View();
        }
    }
}
