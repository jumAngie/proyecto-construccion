﻿using Construccion.API.Models;
using Construccion.WEBUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class ConstruccionesController : Controller
    {
        private readonly HttpClient _httpClient;

        public ConstruccionesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public IActionResult Index()
        {
            var UserName = HttpContext.Session.GetString("user_Nombre");
            if (UserName != "" && UserName != null)
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

        [HttpPost("/Construcciones/Listar")]
        public async Task<IActionResult> Listado()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.GetAsync(builder.GetSection("ApiSettings:baseUrl").Value + "Construcciones/List");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseAPI<ConstruccionesViewModel>>(content);
                var res = result.data;
                return Json(res);
            }
            else
            {
                // manejar error
                return null;
            }
        }

        [HttpPost("/Construcciones/ListarInsumos")]
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
                return Json(res);
            }
            else
            {
                // manejar error
                return null;
            }
        }


        [HttpGet("/Construcciones/ListarDepartamentos")]
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

        [HttpPost("/Construcciones/ListarMunicipiosPorIdDepartamento")]
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

        [HttpPost("/Construcciones/InsertarConstruccion")]
        public async Task<JsonResult> Create(string cons_Proyecto, string cons_ProyectoDescripcion, string muni_id, string cons_Direccion,string cons_FechaInicio, string cons_FechaFin)
        {
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            ConstruccionesViewModel construccionesViewModel1 = new ConstruccionesViewModel();
            construccionesViewModel1.cons_Proyecto = cons_Proyecto;
            construccionesViewModel1.cons_ProyectoDescripcion = cons_ProyectoDescripcion;
            construccionesViewModel1.muni_Id = muni_id;
            construccionesViewModel1.cons_Direccion = cons_Direccion;
            construccionesViewModel1.cons_FechaInicio = cons_FechaInicio;
            construccionesViewModel1.cons_FechaFin = cons_FechaFin;
            construccionesViewModel1.user_UsuCreacion = usuarioId;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<ConstruccionesViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "Construcciones/Insert", construccionesViewModel1);

            if (response.IsSuccessStatusCode)
            {
                string res = await response.Content.ReadAsStringAsync();
                var respuestaX = JsonConvert.DeserializeObject<ResponseAPI<ConstruccionesViewModel>>(res);
                var mensaje = respuestaX.message;
                var resultado = respuestaX.data;
                return Json(new { success = true, resultado });
            }
            return Json(0);
        }


        [HttpPost("/Construcciones/EliminarConstruccion")]
        public async Task<JsonResult> Delete(int cons_Id)
        {
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            ConstruccionesViewModel construccionesViewModel = new ConstruccionesViewModel();
            construccionesViewModel.cons_Id = cons_Id;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<ConstruccionesViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "Construcciones/EliminarConstruccion", construccionesViewModel);

            if (response.IsSuccessStatusCode)
            {
                string res = await response.Content.ReadAsStringAsync();
                var respuestaX = JsonConvert.DeserializeObject<INSERTAPI>(res);
                var mensaje = respuestaX.message;
                var resultado = 1;
                return Json(resultado);
            }
            return Json(0);
        }


        [HttpGet("/Construcciones/ListarEmpleados")]
        public async Task<JsonResult> ListarEmpleadosSinCons()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.GetAsync(builder.GetSection("ApiSettings:baseUrl").Value + "Empleados/ListarEmpleadosSinCons");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseAPI<EmpleadosViewModel>>(content);
                var res = result.data;
                return Json(res);
            }
            else
            {
                // manejar error
                return null;
            }
        }

        [HttpPost("/Construcciones/EmpleadosListarPorIdConstruccion")]
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
                return Json(res);
            }
            else
            {
                // manejar error
                return null;
            }
        }

        [HttpGet("/Construcciones/CargarInsumos")]

        public async Task<JsonResult> ListarInsumos()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.GetAsync(builder.GetSection("ApiSettings:baseUrl").Value + "Insumos/List");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseAPI<InsumosViewModel>>(content);
                var insumos = result.data;
                return Json(insumos);
            }
            else
            {
                // manejar error
                return null;
            }
        }


        [HttpPost("/Construcciones/ListarInsumosPorIdConstruccionTable")]
        public async Task<JsonResult> ListarInsumosPorIdConstruccionTable(int cons_Id)
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
                return Json(res);
            }
            else
            {
                // manejar error
                return null;
            }
        }

        [HttpPost("/Construcciones/InsertarEmpleadosPorConstruccion")]
        public async Task<IActionResult> InsertarEmpleadosPorConstruccion(int cons_Id, int empl_Id)
        {
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            EmpleadosPorConstruccionViewModel empleadosPorConstruccionViewModel = new EmpleadosPorConstruccionViewModel();
            empleadosPorConstruccionViewModel.cons_Id = cons_Id;
            empleadosPorConstruccionViewModel.empl_Id = empl_Id;
            empleadosPorConstruccionViewModel.user_UsuCreacion = usuarioId;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<EmpleadosPorConstruccionViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "EmpleadosConstruccion/InsertEmpleadoConstruccion", empleadosPorConstruccionViewModel);

            if (response.IsSuccessStatusCode)
            {
                string res = await response.Content.ReadAsStringAsync();
                var respuestaX = JsonConvert.DeserializeObject<INSERTAPI>(res);
                var mensaje = respuestaX.message;
                return Json(1);
            }
            return Json(0);
        }


        [HttpPost("/Construcciones/InsertarInsumosPorIdConstruccion")]
        public async Task<IActionResult> InsertarInsumosPorIdConstruccion(int cons_Id, int insm_Id)
        {
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            InsumosPorConstruccionViewModel insumosPorConstruccionViewModel = new InsumosPorConstruccionViewModel();
            insumosPorConstruccionViewModel.cons_Id = cons_Id;
            insumosPorConstruccionViewModel.insm_Id = insm_Id;
            insumosPorConstruccionViewModel.user_UsuCreacion = usuarioId;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<InsumosPorConstruccionViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "InsumosConstruccion/InsertInsumoPorIdConstruccion", insumosPorConstruccionViewModel);

            if (response.IsSuccessStatusCode)
            {
                string res = await response.Content.ReadAsStringAsync();
                var respuestaX = JsonConvert.DeserializeObject<INSERTAPI>(res);
                var mensaje = respuestaX.message;
                return Json(1);
            }
            return Json(0);
        }


        [HttpPost("/Construcciones/EliminarEmpleadoPorIdConstruccion")]
        public async Task<IActionResult> EliminarEmpleadoPorIdConstruccion(int cons_Id, int empl_Id)
        {
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            EmpleadosPorConstruccionViewModel empleados = new EmpleadosPorConstruccionViewModel();
            empleados.cons_Id = cons_Id;
            empleados.empl_Id = empl_Id;
            empleados.user_UsuCreacion = usuarioId;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<EmpleadosPorConstruccionViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "EmpleadosConstruccion/EliminarEmpleadoConstruccion", empleados);

            if (response.IsSuccessStatusCode)
            {
                string res = await response.Content.ReadAsStringAsync();
                var respuestaX = JsonConvert.DeserializeObject<INSERTAPI>(res);
                var mensaje = respuestaX.message;
                return Json(1);
            }
            return Json(0);
        }

        [HttpPost("/Construcciones/EliminarInsumoPorIdConstruccion")]
        public async Task<IActionResult> EliminarInsumoPorIdConstruccion(int cons_Id, int insm_Id)
        {
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            InsumosPorConstruccionViewModel insumos = new InsumosPorConstruccionViewModel();
            insumos.cons_Id = cons_Id;
            insumos.insm_Id = insm_Id;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<InsumosPorConstruccionViewModel>(builder.GetSection("ApiSettings:baseUrl").Value + "EmpleadosConstruccion/EliminarInsumoConstruccion", insumos);

            if (response.IsSuccessStatusCode)
            {
                string res = await response.Content.ReadAsStringAsync();
                var respuestaX = JsonConvert.DeserializeObject<INSERTAPI>(res);
                var mensaje = respuestaX.message;
                return Json(1);
            }
            return Json(0);
        }
    }
}

