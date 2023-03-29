using Construccion.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Construccion.WEBUI.Controllers
{
    public class UnidadesDeMedidaController : Controller
    {

        private readonly HttpClient _httpClient;

        public UnidadesDeMedidaController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Index()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.GetAsync(builder.GetSection("ApiSettings:baseUrl").Value + "UnidadesDeMedida/List");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseAPI<UnidadesMedidaViewModel>>(content);
                var res = result.data;
                return View(res);
            }
            else
            {
                // manejar error
                return null;
            }
        }
    }
}
