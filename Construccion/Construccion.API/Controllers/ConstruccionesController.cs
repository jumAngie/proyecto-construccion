using AutoMapper;
using Construccion.API.Models;
using Construccion.BusinessLogic.Services;
using Construccion.DataAccess;
using Construccion.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Construccion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConstruccionesController : ControllerBase
    {
        private readonly ConstruccionServices _construccionServices;
        private readonly IMapper _mapper;
        public ConstruccionCon db = new ConstruccionCon();

        public ConstruccionesController(ConstruccionServices construccionServices, IMapper mapper)
        {
            _construccionServices = construccionServices;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _construccionServices.ListConstrucciones();
            return Ok(list);
        }

        [HttpPost("ListarConstrucciones")]
        public IActionResult ListarContruccion(ConstruccionesViewModel item)
        {
            var item1 = _mapper.Map<tbConstrucciones>(item);
            var list = _construccionServices.ListConstruccionesPorId(item1);
            return Ok(list);
        }

        [HttpPost("Insert")]

        public IActionResult Insert(ConstruccionesViewModel construccionesViewModel)
        {
            string cons_Proyecto = construccionesViewModel.cons_Proyecto;
            string cons_ProyectoDescripcion = construccionesViewModel.cons_ProyectoDescripcion;
            string muni_Id = construccionesViewModel.muni_Id;         
            string cons_Direccion = construccionesViewModel.cons_Direccion;
            DateTime date = DateTime.ParseExact(construccionesViewModel.cons_FechaInicio, "MM/dd/yyyy", null);
            DateTime date2 = DateTime.ParseExact(construccionesViewModel.cons_FechaFin, "MM/dd/yyyy", null);
            int? usuario = construccionesViewModel.user_UsuCreacion;
            ConstruccionesViewModelInsert construccionesViewModelInsert = new ConstruccionesViewModelInsert();
            construccionesViewModelInsert.cons_Proyecto = cons_Proyecto;
            construccionesViewModelInsert.cons_ProyectoDescripcion = cons_ProyectoDescripcion;
            construccionesViewModelInsert.muni_Id = muni_Id;
            construccionesViewModelInsert.cons_Direccion = cons_Direccion;
            construccionesViewModelInsert.cons_FechaInicio = date;
            construccionesViewModelInsert.cons_FechaFin = date2;
            construccionesViewModelInsert.user_UsuCreacion = usuario;
            var item = _mapper.Map<tbConstrucciones>(construccionesViewModelInsert);
            var response = _construccionServices.CreateConstruccion(item);
            return Ok(response);
        }

        [HttpPost("EliminarConstruccion")]
        public IActionResult EliminarConstruccion(tbConstrucciones item)
        {
            var item1 = _mapper.Map<tbConstrucciones>(item);
            var response = _construccionServices.EliminarConstruccion(item1);
            return Ok(response);
        }
    }
}
