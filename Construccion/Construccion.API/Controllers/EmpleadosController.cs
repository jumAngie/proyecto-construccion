﻿using AutoMapper;
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
    public class EmpleadosController : ControllerBase
    {
        private readonly GeneralesService _generalesServices;
        private readonly IMapper _mapper;
        public ConstruccionCon db = new ConstruccionCon();

        public EmpleadosController(GeneralesService generalesService, IMapper mapper)
        {
            _generalesServices = generalesService;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _generalesServices.ListEmpleados();
            return Ok(list);
        }

        [HttpPost("Insert")]
        public IActionResult Insert(EmpleadosViewModel empleados)
        {
            var item = _mapper.Map<tbEmpleados>(empleados);
            var response = _generalesServices.CreateEmpleados(item);
            return Ok(response);

        }

        [HttpPost("EliminarEmpleados")]
        public IActionResult EliminarEmpleado(EmpleadosViewModel emple)
        {
            var item = _mapper.Map<tbEmpleados>(emple);
            var response = _generalesServices.EliminarEmpleado(item);
            return Ok(response);
        }

        [HttpGet("ListarEmpleadosSinCons")]
        public IActionResult ListarEmpleadosSinCons()
        {   
            var list = _generalesServices.ListarEmpleadosSinCons();
            return Ok(list);
        }

        [HttpGet("EmpleadosPorSexo")]
        public IActionResult EmpleadosChart()
        {
            var empleados = db.tbEmpleados.ToList();
            var total = empleados.Count();
            var hombres = empleados.Where(e => e.empl_Sexo == "M").Count();
            var mujeres = empleados.Where(e => e.empl_Sexo == "F").Count();

            var data = new List<int> { hombres, mujeres };
            var labels = new List<string> { "Hombres", "Mujeres" };

            var viewModel = new EmpleadosChartViewModel { data = data, labels = labels };

            return Ok(viewModel);
        }

        [HttpGet("ListarEstadosCiviles")]

        public IActionResult ListadoEstadosCiviles()
        {
            var estadosCiviles = from u in db.tbEstadosCiviles
                                   select new { esta_ID = u.esta_ID, esta_Descripcion = u.esta_Descripcion };

            return Ok(estadosCiviles.ToList());
        }


        [HttpGet("ListarCargos")]
        public IActionResult ListadoCargos()
        {
            var cargos = from u in db.tbCargos
                                 select new { carg_Id = u.carg_Id, carg_Cargo = u.carg_Cargo };

            return Ok(cargos.ToList());
        }

    }
}
