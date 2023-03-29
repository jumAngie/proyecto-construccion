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
    public class InsumosPorConstruccionController : Controller
    {
        private readonly HttpClient _httpClient;

        public InsumosPorConstruccionController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpPost("InsumosPorConstruccion/ListarInsumos")]
        public async Task<JsonResult> ListarInsumosPorIdConstruccion(int cons_Id)
        {
            InsumosPorConstruccionViewModel insumosPorConstruccionViewModel = new InsumosPorConstruccionViewModel();
            insumosPorConstruccionViewModel.cons_Id = cons_Id;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<InsumosPorConstruccionViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "InsumosConstruccion/InsumosPorIdConstruccion", insumosPorConstruccionViewModel);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseAPI<InsumosPorConstruccionViewModel>>(content);
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
