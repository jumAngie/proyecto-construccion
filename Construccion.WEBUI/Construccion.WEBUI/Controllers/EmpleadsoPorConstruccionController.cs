using Construccion.WEBUI.Models;
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
    public class EmpleadsoPorConstruccionController : Controller
    {
        private readonly HttpClient _httpClient;

        public EmpleadsoPorConstruccionController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/EmpleadosPorConstruccion/EmpleadosListar")]
        public async Task<JsonResult> EmpleadosListar(int cons_Id)
        {
            EmpleadosPorConstruccionViewModel empleadosPorConstruccionViewModel = new EmpleadosPorConstruccionViewModel();
            empleadosPorConstruccionViewModel.cons_Id = cons_Id;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<EmpleadosPorConstruccionViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "EmpleadosConstruccion/EmpleadosPorIdConstruccion", empleadosPorConstruccionViewModel);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseAPI<EmpleadosPorConstruccionViewModel>>(content);
                var res = result.data;
                return Json(new { success = true, res });
            }
            else
            {
                // manejar error
                return null;
            }
        }

    }
}
