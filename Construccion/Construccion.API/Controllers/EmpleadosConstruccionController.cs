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
    public class EmpleadosConstruccionController : Controller
    {
        private readonly ConstruccionServices _construccionServices;
        private readonly IMapper _mapper;
        public ConstruccionCon db = new ConstruccionCon();

        public EmpleadosConstruccionController(ConstruccionServices construccionServices, IMapper mapper)
        {
            _construccionServices = construccionServices;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _construccionServices.ListEmpleadosConstruccion();
            return Ok(list);
        }

        [HttpPost("EmpleadosPorIdConstruccion")]
        public IActionResult EmpleadosPorConstruccion(EmpleadosPorConstruccionViewModel empleadosPorConstruccionViewModel)
        {
            var item = _mapper.Map<tbEmpleadosPorConstruccion>(empleadosPorConstruccionViewModel);
            var pantallas = _construccionServices.ListarEmpleadosPorConstruccion(item);
            return Ok(pantallas);
        }
    }
}
