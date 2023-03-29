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
    }
}
